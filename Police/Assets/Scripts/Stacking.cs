using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;
    private float xMove;
    private float zMove;
    private Vector3 FirsthandcuffPos;
    private Vector3 CurrenthandcuffPos;
    //
    [SerializeField] private float speed;
    //
    List<GameObject> handcuffList = new List<GameObject>();
    private int handcuffListIndexCounter = 0;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        Vector3 forwardMove = Vector3.forward * zMove * speed * Time.deltaTime;
        Vector3 horizontalMove = Vector3.right * xMove * speed * Time.deltaTime;
        PlayerRigidbody.MovePosition(transform.position + forwardMove + horizontalMove);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("handcuffs"))
        {
            handcuffList.Add(other.gameObject);
            if (handcuffList.Count == 1)
            {
                FirsthandcuffPos = GetComponent<MeshRenderer>().bounds.max;
                CurrenthandcuffPos = new Vector3(other.transform.position.x, FirsthandcuffPos.y, other.transform.position.z);
                other.gameObject.transform.position = CurrenthandcuffPos;
                CurrenthandcuffPos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<HandcuffManager>().UpdateCubePosition(transform, true);
            }
            else if (handcuffList.Count > 1)
            {
                other.gameObject.transform.position = CurrenthandcuffPos;
                CurrenthandcuffPos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<HandcuffManager>().UpdateCubePosition(handcuffList[handcuffListIndexCounter].transform, true);
                handcuffListIndexCounter++;
            }
        }
    }
}
