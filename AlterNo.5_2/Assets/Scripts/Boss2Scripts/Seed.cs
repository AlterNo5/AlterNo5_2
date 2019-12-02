using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case "Player":
                other.gameObject.GetComponentInParent<Rigidbody>().AddForce((transform.forward) * 0.5f, ForceMode.Impulse);
                Destroy(this.gameObject);
                break;
            case "Plataformas":
                Destroy(this.gameObject);
                break;
        }

        
    }
}
