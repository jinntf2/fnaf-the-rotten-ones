using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCamera : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float sensibilityMultiplier;
    private float xRotation;
    private Camera cam;

    private void Awake() {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update() {
        float x = Input.GetAxis("Mouse X") * sensibilityMultiplier;
        float y = Input.GetAxis("Mouse Y") * sensibilityMultiplier;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * x);
    }
}
