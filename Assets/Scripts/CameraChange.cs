using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private RenderTexture[] cameraTexture;
    [SerializeField] private Button[] CameraButton;
    [SerializeField] private RawImage ScreenMonitor, ScreenNoise;
    [SerializeField] private float screenNoiseReducer;
    float screenNoiseValue;

    public void C1(){
        ScreenMonitor.texture = cameraTexture[0];
        screenNoiseValue = 1f;
    }
    public void C2(){
        ScreenMonitor.texture = cameraTexture[1];
        screenNoiseValue = 1f;
    }

    private void Update() {
        screenNoiseValue -= screenNoiseReducer * Time.deltaTime;
        screenNoiseValue = Mathf.Clamp(screenNoiseValue, 0.1f, 1.1f);

        ScreenNoise.color = new Color(ScreenNoise.color.r, ScreenNoise.color.g, ScreenNoise.color.b, screenNoiseValue);
    }
}
