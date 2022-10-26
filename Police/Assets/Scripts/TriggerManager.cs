using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public delegate void OnCollectArea();
    public static event OnCollectArea OnEnemyCollect;

    bool isCollecting;
    void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while(true)
        {
            if(isCollecting == true)
            {
                OnEnemyCollect();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            isCollecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isCollecting = false;
        }
    }
}
