using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInput : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float gravity = 19.62f;
    private CharacterController m_char;

    Vector3 velocity;

    private void Awake() {
        m_char = GetComponent<CharacterController>();
    }

    private void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z);
        m_char.Move(Vector3.ClampMagnitude(move, 1f) * speedMultiplier * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
        m_char.Move(velocity * Time .deltaTime);
    }
}
