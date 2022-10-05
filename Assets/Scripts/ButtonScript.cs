using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;
    void Update()
    {
        Material mat = GetComponent<Renderer>().material;
        if(isOn)
            mat.EnableKeyword("_EMISSION");
        else
            mat.DisableKeyword("_EMISSION");
    }
}
