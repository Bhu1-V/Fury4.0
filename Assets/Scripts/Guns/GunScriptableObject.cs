using Fury.ImpactSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Fury.Guns {

    [CreateAssetMenu(fileName = "Gun", menuName = "Guns/Gun", order = 0)]
    public class GunScriptableObject : ScriptableObject {
        public ImpactType impactType;
        public GunType type;
        public FireType fireType;
        public WeaponCategory weaponCategory;
        public string gunName;
        public GameObject modelPrefab;
        public Vector3 spawnPoint;
        public Vector3 spawnRotation;

        public DamageConfigScriptableObject damageConfig;
        public ShootConfigScriptableObject shootConfig;
        public AmmoConfigScriptableObject ammoConfig;
        public TrailConfigScriptableObject trailConfig;
        public AudioConfigScriptableObject audioConfig;

        private MonoBehaviour activeMonoBehaviour;
        private AudioSource shootingAudioSource;
        private GameObject model;
        private Camera activeCamera;
        private float lastShootTime;
        private float initialClickTime;
        private float stopShootingTime;

        private ParticleSystem shootSystem;
        private ObjectPool<TrailRenderer> trailPool;
        private ObjectPool<Bullet> bulletPool;
        private bool lastFrameWantedToShoot;
        private bool shouldShoot;

        /// <summary>
        /// Spawns the Gun Model into the scene
        /// </summary>
        /// <param name="Parent">Parent for the gun model</param>
        /// <param name="ActiveMonoBehaviour">An Active MonoBehaviour that can have Coroutines attached to them.
        /// <param name="Camera">The camera to raycast from. Required if <see cref="ShootConfigScriptableObject.ShootType"/> = <see cref="ShootType.FromCamera"/></paramref>
        /// The input handling script is a good candidate for this.
        /// </param>
        public void Spawn(Transform Parent, MonoBehaviour ActiveMonoBehaviour, Camera Camera = null) {
            this.activeMonoBehaviour = ActiveMonoBehaviour;

            // in editor these will not be properly reset, in build it's fine
            lastShootTime = 0;
            stopShootingTime = 0;
            initialClickTime = 0;
            ammoConfig.CurrentClipAmmo = ammoConfig.ClipSize;
            ammoConfig.CurrentAmmo = ammoConfig.MaxAmmo;

            trailPool = new ObjectPool<TrailRenderer>(CreateTrail);
            if(!shootConfig.IsHitscan) {
                bulletPool = new ObjectPool<Bullet>(CreateBullet);
            }

            if(model == null) {
                model = Instantiate(modelPrefab);
            } else {
                model.SetActive(true);
            }
            model.transform.SetParent(Parent, false);
            model.transform.localPosition = spawnPoint;
            model.transform.localRotation = Quaternion.Euler(spawnRotation);

            activeCamera = Camera;

            shootingAudioSource = model.GetComponent<AudioSource>();
            shootSystem = model.GetComponentInChildren<ParticleSystem>();
        }

        public void Despawn() {
            if(model != null) {
                model.SetActive(false);
            }
        }

        /// <summary>
        /// Used to override the Camera provided in <see cref="Spawn(Transform, MonoBehaviour, Camera)"/>.
        /// Cameras are only required if 
        /// </summary>
        /// <param name="Camera"></param>
        public void UpdateCamera(Camera Camera) {
            activeCamera = Camera;
        }

        /// <summary>
        /// Expected to be called every frame
        /// </summary>
        /// <param name="WantsToShoot">Whether or not the player is trying to shoot</param>
        public void Tick(bool WantsToShoot) {
            model.transform.localRotation = Quaternion.Lerp(
                model.transform.localRotation,
                Quaternion.Euler(spawnRotation),
                Time.deltaTime * shootConfig.RecoilRecoverySpeed
            );

            if(WantsToShoot) {
                lastFrameWantedToShoot = true;
                TryToShoot();
            }

            if(!WantsToShoot && lastFrameWantedToShoot) {
                stopShootingTime = Time.time;
                lastFrameWantedToShoot = false;
                shouldShoot = true;
            }
        }

        /// <summary>
        /// Plays the reloading audio clip if assigned.
        /// Expected to be called on the first frame that reloading begins
        /// </summary>
        public void StartReloading() {
            audioConfig.PlayReloadClip(shootingAudioSource);
        }

        /// <summary>
        /// Handle ammo after a reload animation.
        /// ScriptableObjects can't catch Animation Events, which is how we're determining when the
        /// reload has completed, instead of using a timer
        /// </summary>
        public void EndReload() {
            ammoConfig.Reload();
        }

        /// <summary>
        /// Whether or not this gun can be reloaded
        /// </summary>
        /// <returns>Whether or not this gun can be reloaded</returns>
        public bool CanReload() {
            return ammoConfig.CanReload();
        }

        /// <summary>
        /// Performs the shooting raycast if possible based on gun rate of fire. Also applies bullet spread and plays sound effects based on the AudioConfig.
        /// </summary>
        private void TryToShoot() {
            if(Time.time - lastShootTime - shootConfig.FireRate > Time.deltaTime) {
                float lastDuration = Mathf.Clamp(
                    0,
                    (stopShootingTime - initialClickTime),
                    shootConfig.MaxSpreadTime
                );
                float lerpTime = (shootConfig.RecoilRecoverySpeed - (Time.time - stopShootingTime))
                    / shootConfig.RecoilRecoverySpeed;

                initialClickTime = Time.time - Mathf.Lerp(0, lastDuration, Mathf.Clamp01(lerpTime));
            }

            if(Time.time > shootConfig.FireRate + lastShootTime && shouldShoot) {
                lastShootTime = Time.time;

                if(ammoConfig.CurrentClipAmmo == 0) {
                    audioConfig.PlayOutOfAmmoClip(shootingAudioSource);
                    return;
                }

                shootSystem.Play();
                audioConfig?.PlayShootingClip(shootingAudioSource, ammoConfig.CurrentClipAmmo == 1);

                Vector3 spreadAmount = shootConfig.GetSpread(Time.time - initialClickTime);

                Vector3 shootDirection = Vector3.zero;
                model.transform.forward += model.transform.TransformDirection(spreadAmount);
                if(shootConfig.ShootType == ShootType.FromGun) {
                    shootDirection = shootSystem.transform.forward;
                } else {
                    shootDirection = activeCamera.transform.forward + activeCamera.transform.TransformDirection(spreadAmount);
                }

                shouldShoot = (fireType == FireType.Automatic);
                ammoConfig.CurrentClipAmmo--;

                if(shootConfig.IsHitscan) {
                    DoHitscanShoot(shootDirection);
                } else {
                    DoProjectileShoot(shootDirection);
                }
            }
        }

        /// <summary>
        /// Generates a live Bullet instance that is launched in the <paramref name="ShootDirection"/> direction
        /// with velocity from <see cref="ShootConfigScriptableObject.BulletSpawnForce"/>.
        /// </summary>
        /// <param name="ShootDirection"></param>
        private void DoProjectileShoot(Vector3 ShootDirection) {
            Bullet bullet = bulletPool.Get();
            bullet.gameObject.SetActive(true);
            bullet.OnCollsion += HandleBulletCollision;

            // We have to ensure if shooting from the camera, but shooting real proejctiles, that we aim the gun at the hit point
            // of the raycast from the camera. Otherwise the aim is off.
            // When shooting from the gun, there's no need to do any of this because the recoil is already handled in TryToShoot
            if(shootConfig.ShootType == ShootType.FromCamera
                && Physics.Raycast(
                    GetRaycastOrigin(),
                    ShootDirection,
                    out RaycastHit hit,
                    float.MaxValue,
                    shootConfig.HitMask
                )) {
                Vector3 directionToHit = (hit.point - shootSystem.transform.position).normalized;
                model.transform.forward = directionToHit;
                ShootDirection = directionToHit;
            }

            bullet.transform.position = shootSystem.transform.position;
            bullet.Spawn(ShootDirection * shootConfig.BulletSpawnForce);

            TrailRenderer trail = trailPool.Get();
            if(trail != null) {
                trail.transform.SetParent(bullet.transform, false);
                trail.transform.localPosition = Vector3.zero;
                trail.emitting = true;
                trail.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Performs a Raycast to determine if a shot hits something. Spawns a TrailRenderer
        /// and will apply impact effects and damage after the TrailRenderer simulates moving to the
        /// hit point. 
        /// See <see cref="PlayTrail(Vector3, Vector3, RaycastHit)"/> for impact logic.
        /// </summary>
        /// <param name="ShootDirection"></param>
        private void DoHitscanShoot(Vector3 ShootDirection) {
            if(Physics.Raycast(
                    GetRaycastOrigin(),
                    ShootDirection,
                    out RaycastHit hit,
                    float.MaxValue,
                    shootConfig.HitMask
                )) {
                activeMonoBehaviour.StartCoroutine(
                    PlayTrail(
                        shootSystem.transform.position,
                        hit.point,
                        hit
                    )
                );
            } else {
                activeMonoBehaviour.StartCoroutine(
                    PlayTrail(
                        shootSystem.transform.position,
                        shootSystem.transform.position + (ShootDirection * trailConfig.MissDistance),
                        new RaycastHit()
                    )
                );
            }
        }

        /// <summary>
        /// Returns the proper Origin point for raycasting based on <see cref="ShootConfigScriptableObject.ShootType"/>
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRaycastOrigin() {
            Vector3 origin = shootSystem.transform.position;

            if(shootConfig.ShootType == ShootType.FromCamera) {
                origin = activeCamera.transform.position
                    + activeCamera.transform.forward * Vector3.Distance(
                            activeCamera.transform.position,
                            shootSystem.transform.position
                        );
            }

            return origin;
        }

        /// <summary>
        /// Returns the forward of the spawned gun model
        /// </summary>
        /// <returns></returns>
        public Vector3 GetGunForward() {
            return model.transform.forward;
        }

        /// <summary>
        /// Plays a bullet trail/tracer from start/end point. 
        /// If <paramref name="Hit"/> is not an empty hit, it will also play an impact using the <see cref="SurfaceManager"/>.
        /// </summary>
        /// <param name="StartPoint">Starting point for the trail</param>
        /// <param name="EndPoint">Ending point for the trail</param>
        /// <param name="Hit">The hit object. If nothing is hit, simply pass new RaycastHit()</param>
        /// <returns>Coroutine</returns>
        private IEnumerator PlayTrail(Vector3 StartPoint, Vector3 EndPoint, RaycastHit Hit) {
            TrailRenderer instance = trailPool.Get();
            instance.gameObject.SetActive(true);
            instance.transform.position = StartPoint;
            yield return null; // avoid position carry-over from last frame if reused

            instance.emitting = true;

            float distance = Vector3.Distance(StartPoint, EndPoint);
            float remainingDistance = distance;
            while(remainingDistance > 0) {
                instance.transform.position = Vector3.Lerp(
                    StartPoint,
                    EndPoint,
                    Mathf.Clamp01(1 - (remainingDistance / distance))
                );
                remainingDistance -= trailConfig.SimulationSpeed * Time.deltaTime;

                yield return null;
            }

            instance.transform.position = EndPoint;

            if(Hit.collider != null) {
                HandleBulletImpact(distance, EndPoint, Hit.normal, Hit.collider);
            }

            yield return new WaitForSeconds(trailConfig.Duration);
            yield return null;
            instance.emitting = false;
            instance.gameObject.SetActive(false);
            trailPool.Release(instance);
        }

        /// <summary>
        /// Callback handler for <see cref="Bullet.OnCollsion"/>. Disables TrailRenderer, releases the 
        /// Bullet from the BulletPool, and applies impact effects if <paramref name="Collision"/> is not null.
        /// </summary>
        /// <param name="Bullet"></param>
        /// <param name="Collision"></param>
        private void HandleBulletCollision(Bullet Bullet, Collision Collision) {
            TrailRenderer trail = Bullet.GetComponentInChildren<TrailRenderer>();
            if(trail != null) {
                trail.transform.SetParent(null, true);
                activeMonoBehaviour.StartCoroutine(DelayedDisableTrail(trail));
            }

            Bullet.gameObject.SetActive(false);
            bulletPool.Release(Bullet);

            //if(Collision != null) {
            //    ContactPoint contactPoint = Collision.GetContact(0);

            //    HandleBulletImpact(
            //        Vector3.Distance(contactPoint.point, Bullet.SpawnLocation),
            //        contactPoint.point,
            //        contactPoint.normal,
            //        contactPoint.otherCollider
            //    );
            //}
        }

        /// <summary>
        /// Disables the trail renderer based on the <see cref="TrailConfigScriptableObject.Duration"/> provided
        ///and releases it from the<see cref="trailPool"/>
        /// </summary>
        /// <param name="Trail"></param>
        /// <returns></returns>
        private IEnumerator DelayedDisableTrail(TrailRenderer Trail) {
            yield return new WaitForSeconds(trailConfig.Duration);
            yield return null;
            Trail.emitting = false;
            Trail.gameObject.SetActive(false);
            trailPool.Release(Trail);
        }

        /// <summary>
        /// Calls <see cref="SurfaceManager.HandleImpact(GameObject, Vector3, Vector3, ImpactType, int)"/> and applies damage
        /// if a damagable object was hit
        /// </summary>
        /// <param name="DistanceTraveled"></param>
        /// <param name="HitLocation"></param>
        /// <param name="HitNormal"></param>
        /// <param name="HitCollider"></param>
        private void HandleBulletImpact(
            float DistanceTraveled,
            Vector3 HitLocation,
            Vector3 HitNormal,
            Collider HitCollider) {
            //if(SurfaceManager.Instance != null) {
            //    SurfaceManager.Instance.HandleImpact(
            //            HitCollider.gameObject,
            //            HitLocation,
            //            HitNormal,
            //            impactType,
            //            0
            //        );

            //    if(HitCollider.TryGetComponent(out IDamageable damageable)) {
            //        damageable.TakeDamage(damageConfig.GetDamage(DistanceTraveled));
            //    }
            //} else {
            //    Debug.Log($"SurfaceManager.Instance = null");
            //}
        }

        /// <summary>
        /// Creates a trail Renderer for use in the object pool.
        /// </summary>
        /// <returns>A live TrailRenderer GameObject</returns>
        private TrailRenderer CreateTrail() {
            GameObject instance = new GameObject("Bullet Trail");
            TrailRenderer trail = instance.AddComponent<TrailRenderer>();
            trail.colorGradient = trailConfig.Color;
            trail.material = trailConfig.Material;
            trail.widthCurve = trailConfig.WidthCurve;
            trail.time = trailConfig.Duration;
            trail.minVertexDistance = trailConfig.MinVertexDistance;

            trail.emitting = false;
            trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            return trail;
        }

        /// <summary>
        /// Creates a Bullet for use in the object pool.
        /// </summary>
        /// <returns>A live Bullet GameObject</returns>
        private Bullet CreateBullet() {
            return Instantiate(shootConfig.BulletPrefab);
        }
    }
}