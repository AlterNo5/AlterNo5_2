using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class EnemyCollisionDetection : MonoBehaviour
{
    public HealthManager healthManager;
    Animator player_Anim;
    AudioSource DamagedPlayer;
    public AudioSource MaliDaño;
    public AudioSource ScottDaño;
    public AudioSource SanjinDaño;

    public AudioSource BurbujaMuerte;

    private void Start()
    {
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
        {

            if (PlayerPrefs.GetInt("Index_1") == 0)
            {
                DamagedPlayer = MaliDaño;
            }
            else if (PlayerPrefs.GetInt("Index_1") == 1)
            {
                DamagedPlayer = SanjinDaño;
            }
            else if (PlayerPrefs.GetInt("Index_1") == 2)
            {
                DamagedPlayer = ScottDaño;
            }


        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
        {

            if (PlayerPrefs.GetInt("Index_2") == 0)
            {
                DamagedPlayer = MaliDaño;
            }
            else if (PlayerPrefs.GetInt("Index_2") == 1)
            {
                DamagedPlayer = SanjinDaño;
            }
            else if (PlayerPrefs.GetInt("Index_2") == 2)
            {
                DamagedPlayer = ScottDaño;
            }

        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
        {

            if (PlayerPrefs.GetInt("Index_3") == 0)
            {
                DamagedPlayer = MaliDaño;
            }
            else if (PlayerPrefs.GetInt("Index_3") == 1)
            {
                DamagedPlayer = SanjinDaño;
            }
            else if (PlayerPrefs.GetInt("Index_3") == 2)
            {
                DamagedPlayer = ScottDaño;
            }

        }
    }

    //  *************  Método LoadSceneDelay  *****************
    public void LoadSceneDelay()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);           // llama a la escena de inicio
    }

    //  **************  Método OnTriggerEnter  ******************
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && SceneManager.GetActiveScene().buildIndex != 3)
        {
            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.GetComponent<Animator>();
            player_Anim.SetTrigger("Damage");
            if (!DamagedPlayer.isPlaying)
            {
                DamagedPlayer.Play();
            }

            if (!BurbujaMuerte.isPlaying)
            {
                BurbujaMuerte.Play();
            }
            Destroy(this.gameObject);
            


            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }
        else if (other.tag == "Player" && SceneManager.GetActiveScene().buildIndex == 3)
        {
            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.GetComponent<Animator>();
            player_Anim.SetTrigger("Damage");
            if (!DamagedPlayer.isPlaying)
            {
                DamagedPlayer.Play();
            }

            if (!BurbujaMuerte.isPlaying)
            {
                BurbujaMuerte.Play();
            }
            Destroy(this.gameObject, 5f);



            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }

        else if (other.tag == "Player" && SceneManager.GetActiveScene().buildIndex == 5)
        {
            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.GetComponent<Animator>();
            player_Anim.SetTrigger("Damage");
            if (!DamagedPlayer.isPlaying)
            {
                DamagedPlayer.Play();
            }

            if (!BurbujaMuerte.isPlaying)
            {
                BurbujaMuerte.Play();
            }




            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }

        if (other.tag == "Bullet")
        {
            if (!BurbujaMuerte.isPlaying)
            {
                BurbujaMuerte.Play();
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Arma")
        {
            if (!BurbujaMuerte.isPlaying)
            {
                BurbujaMuerte.Play();
            }
            Destroy(this.gameObject, 2f);
        }
    }
}
