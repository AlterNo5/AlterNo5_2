using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW5CollisionDetectionLimit : MonoBehaviour
{
    EnemyW5Movement onLimit;
    public GameObject enemy;

    void Start()
    {
        onLimit = enemy.GetComponent<EnemyW5Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    onLimit.inRange = true;                  
                    break;
                }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    onLimit.inRange = false;
                    break;
                }
        }
    }
}
