using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XY : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] private float Distance;
    [SerializeField] private Vector3 Direction;
    [SerializeField] private Vector3 Velocity;
    [SerializeField] private float YPos;
    [SerializeField] private float TiltToAddX;
    [SerializeField] private float TiltToAddZ;
    [SerializeField] private float TiltMultiplier = 5f;

    private void Awake() {
        Target = GameObject.Find("Y").transform;
    }

    private void Update() {

        Vector3 TransformPosition = transform.position;
        Vector3 TargetPosition = Target.position;

        Distance = Vector3.Distance(transform.position, Target.position);
        transform.position = Vector3.Lerp(TransformPosition, TargetPosition, 10f * Time.deltaTime);

        Vector3 TransformPositionX = new Vector3(transform.position.x, 0f, 0f);
        Vector3 TransformPositionZ = new Vector3(0f, 0f, transform.position.z);
        Vector3 TargetPositionX = new Vector3(Target.position.x, 0f, 0f);
        Vector3 TargetPositionZ = new Vector3(0f, 0f, Target.position.z);

        Vector3 distanceX = (TargetPositionX - TransformPositionX);
        Vector3 distanceZ = (TargetPositionZ - TransformPositionZ);

        TiltToAddX = distanceX.x * TiltMultiplier;
        TiltToAddZ = distanceZ.z * TiltMultiplier;
        TiltToAddX = Mathf.Clamp(TiltToAddX, -40, 40);
        TiltToAddZ = Mathf.Clamp(TiltToAddZ, -40, 40);

        transform.rotation = Quaternion.Euler(TiltToAddZ, Target.rotation.y, -TiltToAddX);

    }
}
