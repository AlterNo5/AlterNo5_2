using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW5Movement : MonoBehaviour
{
    public GameObject[] spotPoints;
    int currentSpot = 0;
    int prevSpot;

    public float defaultSpeed = 1.0f;
    public float chaseSpeed = 3.0f;
    float wFRadius = 1;

    GameObject player;

    public BoxCollider sightCollider;

    public bool inRange;
    public bool inSight;
    public int inChase = 0;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        prevSpot = currentSpot;

    }

    public void ChasePlayer()
    {
        
    }

    void Update()
    {
        if(inChase == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * chaseSpeed);
        }

        if (inChase == 0)
        {
            if (Vector3.Distance(spotPoints[currentSpot].transform.position, transform.position) < wFRadius)
            {
                currentSpot++;

                if (currentSpot >= spotPoints.Length)
                {
                    currentSpot = 0;
                }

                if (currentSpot == 0)
                {
                    sightCollider.center = new Vector3(0, 0, 5.67f);
                }

                if (currentSpot == 1)
                {
                    sightCollider.center = new Vector3(0, 0, -5.67f);
                }

            }
            prevSpot = currentSpot;
            transform.position = Vector3.MoveTowards(transform.position, spotPoints[currentSpot].transform.position, Time.deltaTime * defaultSpeed);
        }               

        if(inRange && inSight)
        {
            inChase = 1;
        }

        if (inRange ==false)
        {
            inChase = 0;
        }

    }
}
