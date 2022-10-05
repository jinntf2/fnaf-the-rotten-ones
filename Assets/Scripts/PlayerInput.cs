using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField, Range(1, 10)] private float SensibilityMultiplier;
    [SerializeField, Range(0, -90)] private float minClampY;
    [SerializeField, Range(0, 90)] private float maxClampY;
    [SerializeField, Range(0, -180)] private float minClampX;
    [SerializeField, Range(0, 180)] private float maxClampX;
    private float xRotation;
    private float yRotation;

    private void Awake() {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X") * SensibilityMultiplier;
        float y = Input.GetAxis("Mouse Y") * SensibilityMultiplier;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, minClampY, maxClampY);

        yRotation += x;
        yRotation = Mathf.Clamp(yRotation, minClampX, maxClampX);

        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}
