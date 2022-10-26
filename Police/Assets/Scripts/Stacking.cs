using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float xMove;
    private float zMove;
    private Vector3 firsthandcuffPos;
    private Vector3 currenthandcuffPos;
    //
    [SerializeField] private float speed;
    //
    List<GameObject> handcuffList = new List<GameObject>();
    private int handcuffListIndexCounter = 0;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        Vector3 forwardMove = Vector3.forward * zMove * speed * Time.deltaTime;
        Vector3 horizontalMove = Vector3.right * xMove * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + forwardMove + horizontalMove);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("handcuffs"))
        {
            handcuffList.Add(other.gameObject);
            if (handcuffList.Count == 1)
            {
                firsthandcuffPos = GetComponent<MeshRenderer>().bounds.max;
                currenthandcuffPos = new Vector3(other.transform.position.x, firsthandcuffPos.y, other.transform.position.z);
                other.gameObject.transform.position = currenthandcuffPos;
                currenthandcuffPos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<HandcuffManager>().UpdateCubePosition(transform, true);
            }
            else if (handcuffList.Count > 1)
            {
                other.gameObject.transform.position = currenthandcuffPos;
                currenthandcuffPos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<HandcuffManager>().UpdateCubePosition(handcuffList[handcuffListIndexCounter].transform, true);
                handcuffListIndexCounter++;
            }
        }
    }
}
