using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    public GameObject[] spotPoints;
    int currentSpot = 0;
    float rotSpeed;
    public float speed = 1.0f;
    float wFRadius = 1;

    public GameObject[] atkSpots;
    int currentAtkSpot = 0;
    float rotAtkSpeed;
    public float atkSpeed = 1.0f;
    float wFAtkRadius = 1;

    public void Attack2()
    {
        if (Vector3.Distance(atkSpots[currentAtkSpot].transform.position, transform.position) < wFAtkRadius)
        {
            currentAtkSpot++;

            if (currentAtkSpot >= atkSpots.Length)
            {
                currentAtkSpot = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, atkSpots[currentAtkSpot].transform.position, Time.deltaTime * atkSpeed);
    }

    public void MoveAway()
    {
        if (Vector3.Distance(spotPoints[currentSpot].transform.position, transform.position) < wFRadius)
        {
            currentSpot = Random.Range(0, spotPoints.Length);

            if (currentSpot >= spotPoints.Length)
            {
                currentSpot = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, spotPoints[currentSpot].transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                Invoke("Attack2", 1f);
                Invoke("MoveAway", 1f);
                break;
        }
    }

    void Update()
    {        

    }
}
