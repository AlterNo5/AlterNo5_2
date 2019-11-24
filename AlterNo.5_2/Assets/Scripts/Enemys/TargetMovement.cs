using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float speed;
    public float speedValue = 10f;
    public bool chasing;
    private float m_KeyframeStopChase;
    public float stopChase = 5f;
    private float m_KeyframeKeepChase;
    public float keepChase = 3f;
    GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        chasing = true;
        speed = speedValue;
        m_KeyframeKeepChase = 0;
        m_KeyframeStopChase = 0;
    }

    void Update()
    {
        if (chasing == true)
        {
            m_KeyframeStopChase += Time.deltaTime;
        }

        if (m_KeyframeStopChase >= stopChase)
        {
            //Debug.Log("Stop Chase");
            chasing = false;
            speed = .05f;
            m_KeyframeStopChase = 0;
        }

        if (chasing == false)
        {           
            m_KeyframeKeepChase += Time.deltaTime;
        }

        if (m_KeyframeKeepChase >= keepChase)
        {
            //Debug.Log("Chasing");
            chasing = true;
            speed = speedValue;
            m_KeyframeKeepChase = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
}
