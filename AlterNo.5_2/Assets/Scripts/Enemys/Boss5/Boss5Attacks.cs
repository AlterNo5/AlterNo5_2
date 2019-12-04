using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5Attacks : MonoBehaviour
{
    public GameObject defaultSpot;
    public GameObject atkPunchStart;
    public GameObject atkPunchEnd;
    public GameObject atkGrabStart;
    public GameObject atkGrabEnd;

    Boss5TargetMovement targetTopGo;
    Boss5TargetMovement targetBottomGo;

    public GameObject targetTop;
    public GameObject targetBottom;

    GameObject player;

    public float speed;

    public float defaultSpeed = 5f;
    public float atk1Speed = 8f;
    public float atk2Speed = 14f;
    public float atk3Speed = 3.5f;

    public bool goToDefault = false;
    public bool atk1Start = false;
    public bool atk2Start = false;
    private bool atk2End = false;
    public bool atk3Start = false;
    private bool atk3End = false;
    private bool atkTarget = false;

    public Collider handCollider;

    private bool atk1Detected = false;
    private bool atk3Detected = false;
    private bool grabDetected = false;

    private float m_KeyframeAtk3Release;
    private float atk3Release = 1f;

    float wFRadius = .1f;


    //-----------------------------------


    void Start()
    {
        GameObject top = GameObject.Find("TargetTop");
        targetTopGo = top.GetComponent<Boss5TargetMovement>();

        GameObject bottom = GameObject.Find("TargetBottom");
        targetBottomGo = bottom.GetComponent<Boss5TargetMovement>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        speed = defaultSpeed;
        goToDefault = true;
        handCollider.enabled = false;
    }


    //-----------------------------------


    public void GoToDefault()
    {
        speed = defaultSpeed;
        handCollider.enabled = false;
        goToDefault = true;
    }

    public void Atk1()
    {
        targetBottomGo.chasing = true;
        targetTopGo.chasing = true;
        transform.position = Vector3.MoveTowards(transform.position, targetTop.transform.position, Time.deltaTime * speed);
        if (Vector3.Distance(targetTop.transform.position, transform.position) < wFRadius)
        {
            atk1Start = false;
            atkTarget = true;
            return;
        }
    }

    public void Atk2()
    {
        transform.position = Vector3.MoveTowards(transform.position, atkPunchStart.transform.position, Time.deltaTime * speed);
        if (Vector3.Distance(atkPunchStart.transform.position, transform.position) < wFRadius)
        {
            atk2Start = false;
            atk2End = true;
            return;
        }

    }
    public void Atk2End()
    {
        handCollider.enabled = true;
        transform.position = Vector3.MoveTowards(transform.position, atkPunchEnd.transform.position, Time.deltaTime * atk2Speed);
        if (Vector3.Distance(atkPunchEnd.transform.position, transform.position) < wFRadius)
        {
            handCollider.enabled = false;
            atk2End = false;
            Invoke("GoToDefault", 1.5f);
            return;
        }
    }

    public void Atk3()
    {
        atk3Detected = true;
        targetBottomGo.chasing = true;
        targetTopGo.chasing = true;

        transform.position = Vector3.MoveTowards(transform.position, atkGrabStart.transform.position, Time.deltaTime * speed);
        if (Vector3.Distance(atkGrabStart.transform.position, transform.position) < wFRadius)
        {
            atk3Start = false;
            atk3End = true;
            return;
        }
    }
    public void Atk3End()
    {
        transform.position = Vector3.MoveTowards(transform.position, atkGrabEnd.transform.position, Time.deltaTime * speed);
            if (Vector3.Distance(atkGrabEnd.transform.position, transform.position) < wFRadius)
            {
                atk3End = false;
                atkTarget = true;
                return;
            }
    }

    public void Atk3Grab()
    {
        handCollider.enabled = false;
        
        m_KeyframeAtk3Release += Time.deltaTime;
        GameObject.FindWithTag("Player").GetComponent<DummyMovement>().enabled = false;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        if (Vector3.Distance(player.transform.position, transform.position) < wFRadius)
        {
            speed = 0;
        }

        if (m_KeyframeAtk3Release >= atk3Release)
        {
            grabDetected = false;
            //Que le haga daño al jugador aquí                
            GameObject.FindWithTag("Player").GetComponent<DummyMovement>().enabled = true;
            speed = defaultSpeed;
            m_KeyframeAtk3Release = 0;
            goToDefault = true;
        }

    }

    public void AtkTarget()
    {
        handCollider.enabled = true;

        if (atk1Detected)
        {
            speed = atk1Speed;
        }
        if (atk3Detected)
        {
            speed = atk3Speed;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetBottom.transform.position, Time.deltaTime * speed);

        if (Vector3.Distance(targetBottom.transform.position, transform.position) < wFRadius)
        {
            handCollider.enabled = false;
            atkTarget = false;

            if(atk1Detected)
            {
                //Coloca animación de impacto aquí
                atk1Detected = false;
                Invoke("GoToDefault", 2f);
            }
            if (atk3Detected)
            {
                //Coloca animación de agarre aquí
                atk3Detected = false;
                Invoke("GoToDefault", .7f);
            }

            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Player":
                {
                    if(atk3Detected)
                    {
                        grabDetected = true;
                        Debug.Log("Grab");
                    }                  
                    break;
                }
        }
    }


    //-------------------------


    void Update()
    {
        if (grabDetected)
        {
            goToDefault = false;
            atkTarget = false;
            atk3Detected = false;
            CancelInvoke("atkTarget");
            Invoke("Atk3Grab",0f);
        }

        if (goToDefault)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultSpot.transform.position, Time.deltaTime * speed);
            if (Vector3.Distance(defaultSpot.transform.position, transform.position) < wFRadius)
            {
                goToDefault = false;
                return;
            }
        }

        if (atkTarget)
        {
            Invoke("AtkTarget", .7f);
        }

        if (atk1Start)
        {
            atk1Detected = true;
            Invoke("Atk1", .3f);
        }

        if (atk2Start)
        {
            Invoke("Atk2", .4f);
        }

        if (atk2End)
        {
            Invoke("Atk2End", 1.5f);
        }

        if (atk3Start)
        {
            atk3Detected = true;
            Invoke("Atk3", .2f);
        }

        if (atk3End)
        {
            Invoke("Atk3End", .1f);
        }
    }
}
