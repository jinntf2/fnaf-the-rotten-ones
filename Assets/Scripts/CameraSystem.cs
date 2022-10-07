using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Transform cameraObject;
    [SerializeField] private KeyCode CameraUpKey;
    [SerializeField] private PCamera pc;
    [HideInInspector] public bool isOn;
    Vector3 DefaultPosition;
    Vector3 UpPosition;

    private void Awake() {
        DefaultPosition = cameraObject.localPosition;
        UpPosition = new Vector3(cameraObject.localPosition.x, 0.5f, cameraObject.localPosition.z);
    }
    void Update()
    {
        if(Input.GetKeyDown(CameraUpKey)){
            isOn = !isOn;
        }

        if(isOn)
            cameraObject.localPosition = Vector3.Lerp(cameraObject.localPosition, UpPosition, 10f * Time.deltaTime);
        else
            cameraObject.localPosition = Vector3.Lerp(cameraObject.localPosition, DefaultPosition, 10f * Time.deltaTime);

        if(!isOn && cameraObject.localPosition.y <= -0.6f){
            cameraObject.gameObject.SetActive(false);
            pc.canMoveC = true;
        }
        else{
            cameraObject.gameObject.SetActive(true);
            pc.canMoveC = false;
        }
    }
}
