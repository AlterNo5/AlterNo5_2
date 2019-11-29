using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    public float speed = 1f;

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime)));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime)));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z ));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = (new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z ));
        }
    }
}
