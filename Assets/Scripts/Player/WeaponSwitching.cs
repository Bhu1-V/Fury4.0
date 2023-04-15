using Fury.Guns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class WeaponSwitching : MonoBehaviour {

    public Camera Camera;

    [SerializeField]
    private Transform gunParent;

    [SerializeField]
    private LoadOutScriptableObject loadOut;

    [SerializeField]
    private GunType primaryGunType;

    [Space]
    [Header("Runtime Filled")]
    public GunScriptableObject activeGun;

    private void Awake() {
        activeGun = loadOut.GetGun(WeaponCategory.Primary);

        if(activeGun == null) {
            Debug.LogError($"No GunScriptableObject found for GunType: {activeGun}");
            return;
        }

        activeGun.Spawn(gunParent, this, Camera);
    }

    private void Update() {

        if(Keyboard.current.digit1Key.wasPressedThisFrame) {
            SwitchWeapon(WeaponCategory.Primary);
        } else
        if(Keyboard.current.digit2Key.wasPressedThisFrame) {
            SwitchWeapon(WeaponCategory.Secondary);
        } else
        if(Keyboard.current.digit3Key.wasPressedThisFrame) {
            SwitchWeapon(WeaponCategory.Throwable);
        } else
        if(Keyboard.current.digit4Key.wasPressedThisFrame) {
            SwitchWeapon(WeaponCategory.Meele);
        } else
        if(Keyboard.current.digit5Key.wasPressedThisFrame) {
            SwitchWeapon(WeaponCategory.SpecialClass);
        }
    }

    public void SwitchWeapon(WeaponCategory category) {
        GunScriptableObject gun = loadOut.GetGun(category);

        if(gun == null) {
            Debug.Log($"Trying to switch to an Unavailable Gun");
            return;
        }

        activeGun.Despawn();
        activeGun = gun;
        activeGun.Spawn(gunParent, this, Camera);
    }
}
