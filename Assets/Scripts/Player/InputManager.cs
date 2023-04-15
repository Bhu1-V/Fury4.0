using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerInput.ExtraActions extras;
    private PlayerInput.WeaponHandlingActions weaponHandling;

    [SerializeField]
    private PlayerMovement playerMove;

    [SerializeField]
    private PlayerLook playerlook;

    [SerializeField]
    private WeaponHandling playerWeaponHandle;

    private void Awake() {
        playerInput = new PlayerInput();
        onFoot = playerInput.onFoot;
        extras = playerInput.extra;
        weaponHandling = playerInput.weaponHandling;

        // Jump Event
        onFoot.Jump.performed += ctx => playerMove.Jump();

        // Escape Event
        extras.Escape.performed += ctx => playerlook.EscapeFocus();

        // TO-Do: Fire Event (Handled Inpedentedly in WeaponHandling) 

        // TO-Do: Reload Event (Handled Inpedentedly in WeaponHandling) 
    }

    public void Update() {
        playerMove.ProcessMove(onFoot.Move.ReadValue<Vector2>());
        playerlook.ProcessLook(onFoot.MouseLook.ReadValue<Vector2>());
    }

    private void OnEnable() {
        onFoot.Enable();
        extras.Enable();
        weaponHandling.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
        extras.Disable();
        weaponHandling.Disable();
    }
}
