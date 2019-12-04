using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW5Lighting : MonoBehaviour

{
    public HealthManager healthManager;
    Animator player_Anim;
    AudioSource DamagedPlayer;
    public AudioSource MaliDaño;
    public AudioSource ScottDaño;
    public AudioSource SanjinDaño;

    public AudioSource RayitoSound;

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

    //  **************  Método OnTriggerEnter  ******************
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.GetComponent<Animator>();
            player_Anim.SetTrigger("Damage");
            if (!DamagedPlayer.isPlaying)
            {
                DamagedPlayer.Play();
            }

            if (!RayitoSound.isPlaying)
            {
                RayitoSound.Play();
            }
            



            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }
    }

    public void DestruyeEsto()
    {
        Destroy(this.gameObject);
    }
}

