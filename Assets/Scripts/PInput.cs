using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInput : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float gravity = 19.62f;
    [SerializeField] private float HeadBobSpeed;
    [SerializeField] private float HeadBobIntensity;
    private Camera m_cam;
    private CharacterController m_char;
    float timer;
    float defaultY;
    

    Vector3 velocity;

    private void Awake() {
        m_char = GetComponent<CharacterController>();
        m_cam = GetComponentInChildren<Camera>();
        defaultY = m_cam.transform.localPosition.y;
    }

    private void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z);
        m_char.Move(Vector3.ClampMagnitude(move, 1f) * speedMultiplier * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
        m_char.Move(velocity * Time .deltaTime);

        if(move.magnitude != 0){
            HeadBob();
        }
        else{
            m_cam.transform.localPosition = new Vector3(0f, Mathf.Lerp(m_cam.transform.localPosition.y, defaultY, 10f * Time.deltaTime), 0f);
        }
    }

    private void HeadBob(){
        timer += Time.deltaTime * HeadBobSpeed;
        float sinAmountY = (Mathf.Sin(timer) * HeadBobIntensity);

        m_cam.transform.localPosition = new Vector3(0f, Mathf.Lerp(m_cam.transform.localPosition.y,(defaultY + sinAmountY), 10f * Time.deltaTime), 0f);
    }
}
