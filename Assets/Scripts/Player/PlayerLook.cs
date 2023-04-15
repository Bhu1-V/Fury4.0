using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    [SerializeField]
    private Transform viewPoint;

    [SerializeField]
    private float xSensitivity = 30f;
    [SerializeField]
    private float ySensitivity = 30f;

    [SerializeField]
    private float yLookMaxAngle = 80f;

    private Camera playerCam;
    private float xRotation = 0f;

    private void Awake() {
        playerCam = Camera.main;
    }

    public void ProcessLook(Vector2 input) {

        // Lock Cursor if it isn't Locked
        if(Cursor.lockState != CursorLockMode.Locked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -yLookMaxAngle, yLookMaxAngle);

        viewPoint.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }

    public void EscapeFocus() {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate() {
        playerCam.transform.SetPositionAndRotation(viewPoint.position, viewPoint.rotation);
    }
}
