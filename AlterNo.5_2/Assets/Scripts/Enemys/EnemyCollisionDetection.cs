using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionDetection : MonoBehaviour
{
    public HealthManager healthManager;
    Animator player_Anim;

    private void Start()
    {
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();

    }

    //  *************  Método LoadSceneDelay  *****************
    public void LoadSceneDelay()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);           // llama a la escena de inicio
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

            Destroy(this.gameObject);

            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }

        if (other.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

    }
}
