using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private KeyCode DoorKey = KeyCode.Mouse0;
    [SerializeField] private LayerMask buttonMask;

    private void Awake() {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        RaycastHit hit;
        if(Input.GetKeyDown(DoorKey) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, buttonMask)){
            ButtonScript button = hit.transform.GetComponent<ButtonScript>();
            if(button != null){
                button.isOn = !button.isOn;
            }
        }

        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.blue);
    }
}
