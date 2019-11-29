using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5TargetMovement : MonoBehaviour
{
    private float speed = 100f;
    public bool chasing;
    private float m_KeyframeStopChase;
    public float stopChase = .5f;
    GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        chasing = true;
        m_KeyframeStopChase = 0;
    }

    void Update()
    {
        if (chasing == true)
        {
            m_KeyframeStopChase += Time.deltaTime;
            speed = 100f;
        }

        if (m_KeyframeStopChase >= stopChase)
        {
            chasing = false;
            speed = 0;
            m_KeyframeStopChase = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, player.transform.position.z), speed);
    }
}
