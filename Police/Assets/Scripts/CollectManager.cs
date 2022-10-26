using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public Transform CollectPoint;
    public GameObject EnemyPrefab;
    int EnemyLimit = 5;
    private void OnEnable()
    {
        TriggerManager.OnEnemyCollect += GetEnemy;
    }

    private void OnDisable()
    {
        TriggerManager.OnEnemyCollect -= GetEnemy;

    }

    void GetEnemy()
    {
        if(EnemyList.Count <= EnemyLimit)
        {
            GameObject temp = Instantiate(EnemyPrefab,CollectPoint);
            temp.transform.position = new Vector3(CollectPoint.position.x, 0.5f+((float)EnemyList.Count / 20), CollectPoint.position.z);
            EnemyList.Add(temp);
        }
    }

}
