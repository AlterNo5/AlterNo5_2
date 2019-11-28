using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case "Player":
                other.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward) * 0.5f, ForceMode.Impulse);
                Destroy(other.gameObject);
                break;
            case "Ground":
                Destroy(this.gameObject);
                break;
        }

        
    }
}
