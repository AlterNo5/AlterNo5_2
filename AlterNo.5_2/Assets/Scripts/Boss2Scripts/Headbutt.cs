using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Headbutt : MonoBehaviour
{

   

    public void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Player"))
        {
            transform.parent.SendMessage("Headbutt", other.gameObject, SendMessageOptions.DontRequireReceiver);
            other.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward + (transform.up * 0.5f)) * 8f, ForceMode.Impulse);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            GetComponent<BoxCollider>().enabled = false;
            
        }
    }
}
