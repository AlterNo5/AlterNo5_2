using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW5CollisionDetectionSight : MonoBehaviour
{
    EnemyW5Movement onSight;
    public GameObject enemy;

    void Start()
    {
        onSight = enemy.GetComponent<EnemyW5Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    onSight.inSight = true;
                    onSight.self_Anim.SetTrigger("Detection");
                    onSight.self_Anim.SetBool("DetectionRange", true);
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
                    onSight.inSight = false;
                    break;
                }
        }
    }
}
