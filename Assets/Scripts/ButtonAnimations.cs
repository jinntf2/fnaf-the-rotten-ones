using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimations : MonoBehaviour
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highlitedColor;
    [SerializeField] private RawImage[] CameraButtons;

    private void Awake() {
        CameraButtons[0].color = normalColor;
        CameraButtons[1].color = normalColor;
    }

    public void C1Enter(){
        CameraButtons[0].color = highlitedColor;
    }
    public void C1Exit(){
        CameraButtons[0].color = normalColor;
    }
    public void C2Enter(){
        CameraButtons[1].color = highlitedColor;
    }
    public void C2Exit(){
        CameraButtons[1].color = normalColor;
    }
}
