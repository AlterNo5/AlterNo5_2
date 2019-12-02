using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Headbutt : MonoBehaviour
{
    HealthManager healthManager;
    Animator player_Anim;

    private void Start()
    {
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();

    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            transform.parent.SendMessage("Headbutt", other.gameObject, SendMessageOptions.DontRequireReceiver);
            other.gameObject.GetComponentInParent<Rigidbody>().AddForce((transform.forward + (transform.up * 0.5f)) * 8f, ForceMode.Impulse);

            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.GetComponent<Animator>();
            player_Anim.SetTrigger("Damage");
            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
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
