using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{

    public DynamicJoystick dynamicJoystick;
    public float speed;
    public float turnSpeed;

    private void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
    }

    private void JoystickMovement()
    {
        float Horizontal = dynamicJoystick.Horizontal;
        float Vertical = dynamicJoystick.Vertical;
        Vector3 addedPos = new Vector3(x: Horizontal * speed * Time.deltaTime, y: 0, z: Vertical * speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * Vertical + Vector3.right * Horizontal;
        transform.rotation = Quaternion.Slerp(a: transform.rotation, b: Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
}
