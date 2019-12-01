using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.forward * (8 * Time.deltaTime));

        if(transform.position.z>10 || transform.position.z < -10)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plataformas"))
        {
            Destroy(this.gameObject);

        }
        else if (other.CompareTag("Player"))
        {
            //Codigo para hacer daño al player
        }
    }
}
