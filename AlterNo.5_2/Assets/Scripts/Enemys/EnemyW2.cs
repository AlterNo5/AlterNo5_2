using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW2 : MonoBehaviour
{
    public HealthManager healthManager;
    Animator player_Anim;
    Animator self_Anim;
    EnemyMovementAB isMoving;

    private void Start()
    {
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        self_Anim = GetComponent<Animator>();
        isMoving = GetComponent<EnemyMovementAB>();
        if (isMoving != null)
        {
            self_Anim.SetBool("Moving", true);
        }

    }


    //  **************  Método OnTriggerEnter  ******************
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.gameObject.GetComponentInChildren<Animator>();
            player_Anim.SetTrigger("Damage");

            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

    }
}
