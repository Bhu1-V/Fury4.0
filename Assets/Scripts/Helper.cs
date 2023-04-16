using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Helper : MonoBehaviour {
    public static Camera Camera;


    private static PointerEventData _eventDataCurrentPosition;
    private static List<RaycastResult> _results;

    public static bool IsOverUI() {
        _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Mouse.current.position.ReadValue() };
        _results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
        return _results.Count > 0;
    }

    public static void LockMouse() {
        // Lock Cursor if it isn't Locked
        if(Cursor.lockState != CursorLockMode.Locked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
