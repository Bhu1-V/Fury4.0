using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Fury.Guns;

public class WeaponHandling : MonoBehaviour {
    public WeaponSwitching GunSelector;

    [SerializeField]
    private bool AutoReload = true;

    [SerializeField]
    private Image crosshair;

    private bool IsReloading;

    private void Update() {
        GunSelector.activeGun.Tick(
            !IsReloading
            && Application.isFocused && Mouse.current.leftButton.isPressed
            && GunSelector.activeGun != null
        );

        if(ShouldManualReload() || ShouldAutoReload()) {
            GunSelector.activeGun.StartReloading();
            IsReloading = true;
            EndReload();
        }

        UpdateCrosshair();
    }

    private void UpdateCrosshair() {
        if(GunSelector.activeGun.shootConfig.ShootType == ShootType.FromGun) {
            Vector3 gunTipPoint = GunSelector.activeGun.GetRaycastOrigin();
            Vector3 forward = GunSelector.activeGun.GetGunForward();

            Vector3 hitPoint = gunTipPoint + forward * 10;
            if(Physics.Raycast(gunTipPoint, forward, out RaycastHit hit, float.MaxValue, GunSelector.activeGun.shootConfig.HitMask)) {
                hitPoint = hit.point;
            }
            Vector3 screenSpaceLocation = GunSelector.Camera.WorldToScreenPoint(hitPoint);

            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)crosshair.transform.parent,
                screenSpaceLocation,
                null,
                out Vector2 localPosition)) {
                crosshair.rectTransform.anchoredPosition = localPosition;
            } else {
                crosshair.rectTransform.anchoredPosition = Vector2.zero;
            }
        }
    }

    private bool ShouldManualReload() {
        return !IsReloading
            && Keyboard.current.rKey.wasReleasedThisFrame
            && GunSelector.activeGun.CanReload();
    }

    private bool ShouldAutoReload() {
        return !IsReloading
            && AutoReload
            && GunSelector.activeGun.ammoConfig.CurrentClipAmmo == 0
            && GunSelector.activeGun.CanReload();
    }

    private void EndReload() {
        GunSelector.activeGun.EndReload();
        IsReloading = false;
    }
}
