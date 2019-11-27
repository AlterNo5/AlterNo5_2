using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAB : MonoBehaviour
{   
    public GameObject[] spotPoints;
    int currentSpot = 0;
    float rotSpeed;
    public float speed = 1.0f;
    float wFRadius = 1;
    public bool randomMove = false;

    void Update()
    {       
        if(Vector3.Distance(spotPoints[currentSpot].transform.position, transform.position) < wFRadius)
        {
            if (randomMove)
            {
                currentSpot = Random.Range(0, spotPoints.Length);
            }
            else
            {
                currentSpot++;
            }
            
            if (currentSpot >= spotPoints.Length)
            {
                currentSpot = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, spotPoints[currentSpot].transform.position, Time.deltaTime * speed);
    }
}
