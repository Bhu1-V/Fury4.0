using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fury.Guns {
    [CreateAssetMenu(fileName = "Gun", menuName = "Guns/LoadOut")]
    class LoadOutScriptableObject : ScriptableObject {
        private const int LOAD_OUT_SIZE = 5;
        [SerializeField]
        private List<GunScriptableObject> weapons;

        public class WeaponComparer : IComparer<GunScriptableObject> {
            public int Compare(GunScriptableObject x, GunScriptableObject y) {
                if(x == null || y == null) {
                    return 0;
                }
                // Compare by age
                return x.weaponCategory.CompareTo(y.weaponCategory);
            }
        }

        public List<GunScriptableObject> GetLoadOut() {
            return weapons;
        }

        public GunScriptableObject GetGun(WeaponCategory weaponCategory) {
            OnValidate();
            if(weapons.Count == 0 || weapons.Count < (int)weaponCategory) {
                Debug.LogError($"Trying to Access {weaponCategory} in the loadOut but it Doesn't Have one loadOut Count = {weapons.Count}");
                return null;
            }
            return weapons[(int)weaponCategory];
        }

        public void AddWeapon(GunScriptableObject newWeapon) {
            int newIndex = (int)newWeapon.weaponCategory;
            weapons.Insert(newIndex, newWeapon);
            OnValidate();
        }

        private void OnValidate() {
            Debug.Log($"Validating LoadOut and Count = {weapons.Count}");
            weapons.Sort(new WeaponComparer());

            if(weapons.Count > LOAD_OUT_SIZE) {
                List<GunScriptableObject> newWeapons = new List<GunScriptableObject>(LOAD_OUT_SIZE);
                foreach(GunScriptableObject gun in weapons) {
                    if(newWeapons.Count < (int)gun.weaponCategory + 1) {
                        newWeapons.Add(gun);
                    }
                }
                weapons = newWeapons;
            }

            if(weapons.IndexOf(null) > -1) {
                foreach(GunScriptableObject weapon in weapons) {
                    List<GunScriptableObject> newWeapons = new List<GunScriptableObject>(LOAD_OUT_SIZE);
                    for(int i = 0; i < LOAD_OUT_SIZE; i++) {
                        newWeapons.Add(null);
                    }
                    foreach(GunScriptableObject gun in weapons) {
                        if(gun) {
                            newWeapons[(int)gun.weaponCategory] = gun;
                        }
                    }
                    weapons = newWeapons;
                }
            }
        }
    }
}