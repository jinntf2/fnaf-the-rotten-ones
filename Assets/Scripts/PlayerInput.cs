using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float Sensibility;
    private float xRotation;
    private float yRotation;

    private void Awake() {
        if(cam != null)
            cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X") * Sensibility * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * Sensibility * Time.deltaTime;

        xRotation -= y;
        yRotation -= x;
        transform.rotation = Quaternion.Euler(xRotation, -yRotation, 0f);
    }
}
