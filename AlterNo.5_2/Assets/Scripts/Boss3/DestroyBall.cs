using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Existo");
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (7.2F * Time.deltaTime));

        if(transform.position.z>5 || transform.position.z < -24)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("TePegue");
            Destroy(this.gameObject);
        }
    }
}
