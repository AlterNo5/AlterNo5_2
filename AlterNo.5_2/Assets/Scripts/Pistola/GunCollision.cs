using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollision : MonoBehaviour
{



    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        
    }
}
