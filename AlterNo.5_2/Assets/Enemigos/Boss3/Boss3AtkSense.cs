using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AtkSense : MonoBehaviour
{
    // Start is called before the first frame updat

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
    
            transform.parent.parent.SendMessage("AttackRange", true, SendMessageOptions.DontRequireReceiver);
            if(transform.parent.parent.GetComponent<BallBoss>().agresiveForm == false)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1.5f, 1f) * 2, ForceMode.Impulse);
            }

            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.parent.SendMessage("AttackRange", false, SendMessageOptions.DontRequireReceiver);
        }
            
    }
}
