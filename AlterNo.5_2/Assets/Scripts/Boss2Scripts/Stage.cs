using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
           
            transform.GetChild(0).SendMessage("inCombat", true, SendMessageOptions.DontRequireReceiver);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetChild(0).SendMessage("inCombat", false, SendMessageOptions.DontRequireReceiver);
        }
    }
}
