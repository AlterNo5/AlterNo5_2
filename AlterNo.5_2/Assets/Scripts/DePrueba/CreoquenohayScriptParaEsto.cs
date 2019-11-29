using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreoquenohayScriptParaEsto : MonoBehaviour
{
    public bool rotation;
    public float m_turnSpeed;
    public bool movement;
    public float m_movementSpeed;
    public bool touchB;    
    public Transform puntoA;
    public Transform puntoB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation)
        {
            transform.Rotate(0, 0, m_turnSpeed * Time.deltaTime);
        }
        if (movement)
        {
            if (!touchB)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoB.transform.position, m_movementSpeed * Time.deltaTime);
                if (transform.position == puntoB.position)
                {
                    touchB = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoA.transform.position, m_movementSpeed * Time.deltaTime);
                if (transform.position == puntoA.position)
                {
                    touchB = false;
                }
            }
        }

    }
}
