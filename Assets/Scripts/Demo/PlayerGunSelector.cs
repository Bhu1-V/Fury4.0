using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fury.Guns.Demo {
    [DisallowMultipleComponent]
    public class PlayerGunSelector : MonoBehaviour {
        public Camera Camera;
        [SerializeField]
        private GunType Gun;
        [SerializeField]
        private Transform GunParent;
        [SerializeField]
        private List<GunScriptableObject> Guns;
        [SerializeField]
        private PlayerIK InverseKinematics;

        [Space]
        [Header("Runtime Filled")]
        public GunScriptableObject ActiveGun;

        private void Awake() {
            GunScriptableObject gun = Guns.Find(gun => gun.type == Gun);

            if(gun == null) {
                Debug.LogError($"No GunScriptableObject found for GunType: {gun}");
                return;
            }

            ActiveGun = gun;
            gun.Spawn(GunParent, this, Camera);

            //// some magic for IK
            //Transform[] allChildren = GunParent.GetComponentsInChildren<Transform>();
            //InverseKinematics.LeftElbowIKTarget = allChildren.FirstOrDefault(child => child.name == "LeftElbow");
            //InverseKinematics.RightElbowIKTarget = allChildren.FirstOrDefault(child => child.name == "RightElbow");
            //InverseKinematics.LeftHandIKTarget = allChildren.FirstOrDefault(child => child.name == "LeftHand");
            //InverseKinematics.RightHandIKTarget = allChildren.FirstOrDefault(child => child.name == "RightHand");
        }

        public string GenerateRandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomString = "";

            for(int i = 0; i < length; i++) {
                int randomIndex = Random.Range(0, chars.Length);
                randomString += chars[randomIndex];
            }

            return randomString;
        }

        private void Update() {
            if(Keyboard.current.lKey.wasReleasedThisFrame) {
                // Create a new instance of the MyData class
                GunScriptableObject newData = ScriptableObject.CreateInstance<GunScriptableObject>();

                // Set some data on the new instance
                newData.weaponCategory = (WeaponCategory)Random.Range(0, 5);
                newData.gunName = GenerateRandomString(Random.Range(10, 16));

                // Save the new instance as an asset in the project
                AssetDatabase.CreateAsset(newData, $"Assets/DELETE These/{newData.gunName}.asset");

                // Refresh the asset database to make sure the new asset shows up in the Project window
                AssetDatabase.Refresh();
            }
        }
    }
}
