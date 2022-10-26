using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float ChaseSpeed = 5;

    private void LateUpdate()
    {
        Vector3 desPos = Target.position + Offset;  
        transform.position = Vector3.Lerp(transform.position, desPos, ChaseSpeed);
    }
}
