using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW5Movement : MonoBehaviour
{
    public GameObject[] spotPoints;
    int currentSpot = 0;
    int prevSpot;

    public float defaultSpeed = 1.0f;
    public float lastSpeed;
    public float chaseSpeed = 3.0f;
    float wFRadius = 1;

    public Transform Origin;
    public GameObject Rayo;
    public GameObject[] Blast;

    public GameObject player;

    public bool inRange;
    public bool inSight;
    public int inChase = 0;

    public Animator self_Anim;
    public float m_turnSpeed;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        self_Anim = GetComponent<Animator>();

        prevSpot = currentSpot;
        if(spotPoints != null && self_Anim != null)
        {
            self_Anim.SetBool("Walking", true);
        }

    }

    public void ChasePlayer()
    {
        
    }

    void Update()
    {
        if(inChase == 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * chaseSpeed);
        }

        if (inChase == 0)
        {
            if (Vector3.Distance(spotPoints[currentSpot].transform.position, gameObject.transform.position) < wFRadius)
            {
                currentSpot++;

                if (currentSpot >= spotPoints.Length)
                {
                    currentSpot = 0;
                }
            }
            prevSpot = currentSpot;
            if (spotPoints[currentSpot].transform.position.x > transform.position.x)
            {
                Quaternion target = Quaternion.Euler(0, 90, 0);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, m_turnSpeed * Time.deltaTime);
            }
            if (spotPoints[currentSpot].transform.position.x < transform.position.x)
            {
                Quaternion target = Quaternion.Euler(0, 270, 0);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target, m_turnSpeed * Time.deltaTime);
            }
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, spotPoints[currentSpot].transform.position, Time.deltaTime * defaultSpeed);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lastSpeed = chaseSpeed;
            chaseSpeed = 0;
            self_Anim.SetBool("AttackRange", true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            chaseSpeed = lastSpeed;
            lastSpeed = 0;
            self_Anim.SetBool("AttackRange", false);
        }
    }

    public void Attack()
    {        
            Instantiate(Rayo, Origin);
    }
}
