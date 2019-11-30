using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    public GameObject[] spotPoints;
    public GameObject atkStartPoint;
    public GameObject atkEndPoint;
    public GameObject bullet;
    public Transform cannon;
    int currentSpot = 0;
    int prevSpot;
    public float speed = 1.0f;
    public float atkStartSpeed = .7f;
    public float atkEndSpeed = 2.0f;
    public float cadencia;
    float wFRadius = 1;
    public bool moveOut = false;
    public bool atkStart = false;
    public bool canAttack = false;
    public bool atkEnd = false;

    private void Start()
    {
        prevSpot = currentSpot;
        moveOut = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                atkStart = true;
                atkEnd = false;
                canAttack = true;
                StartCoroutine(shoot());
                break;
        }
    }
    public void MoveBoss ()
    {
        transform.position = Vector3.MoveTowards(transform.position, spotPoints[currentSpot].transform.position, Time.deltaTime * speed);
    }

    void Update()
    {

        if (atkStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, atkStartPoint.transform.position, Time.deltaTime * atkStartSpeed);
            if (Vector3.Distance(atkStartPoint.transform.position, transform.position) < wFRadius)
            {
                atkStart = false;
                atkEnd = true;                
                return;
            }
        }

        if (atkEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, atkEndPoint.transform.position, Time.deltaTime * atkEndSpeed);
            if (Vector3.Distance(atkEndPoint.transform.position, transform.position) < wFRadius)
            {
                atkEnd = false;                
                moveOut = true;
                return;
            }
        }

        if (moveOut)
        {
            if (Vector3.Distance(spotPoints[currentSpot].transform.position, transform.position) < wFRadius)
            {
                currentSpot = Random.Range(0, spotPoints.Length);

                while (prevSpot == currentSpot)
                {
                    currentSpot = Random.Range(0, spotPoints.Length);
                }

                moveOut = false;
                return;
            }
            prevSpot = currentSpot;
            Invoke("MoveBoss", 0f);

            if (currentSpot >= spotPoints.Length)
            {
                currentSpot = 0;
            }
        }

    }

    IEnumerator shoot()
    {
        while (canAttack == true)
        {
            yield return new WaitForSeconds(cadencia);
            Instantiate(bullet, cannon.transform.position, cannon.transform.rotation);
        }        
    }
}
