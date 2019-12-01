using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Anim : MonoBehaviour
{
    public Animator naveAnim;
    public Animator pezAnim;

    public HealthManager healthManager;
    public EnemyStatus hP;
    Animator player_Anim;

    private void Start()
    {
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        hP = GetComponent<EnemyStatus>();
        naveAnim = GetComponent<Animator>();
        pezAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    //  **************  Método OnTriggerEnter  ******************
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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

        if (other.tag == "Bullet")
        {
            hP.HitPoints -= 1;
            naveAnim.SetTrigger("Damage");
            pezAnim.SetTrigger("Damage");
            if (hP.HitPoints <= 0)
            {
                pezAnim.SetBool("Dead", true);
                naveAnim.SetBool("Dead", true);
            }
        }

    }

    public void muerte()
    {
            Destroy(transform.parent.gameObject);
    }
}
