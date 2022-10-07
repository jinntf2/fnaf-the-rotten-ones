using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCamera : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float sensibilityMultiplier;
    [SerializeField] private CameraSystem cs;
    [SerializeField] private RawImage crosshair;
    [HideInInspector] public bool canMoveC;
    private float xRotation;
    private Camera cam;

    private void Awake() {
        cam = GetComponentInChildren<Camera>();
    }
    private void Update() {
        if(canMoveC){
            float x = Input.GetAxis("Mouse X") * sensibilityMultiplier;
            float y = Input.GetAxis("Mouse Y") * sensibilityMultiplier;

            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * x);

            crosshair.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else{
            xRotation = Mathf.Lerp(xRotation, 0f, 10f * Time.deltaTime);
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            crosshair.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
