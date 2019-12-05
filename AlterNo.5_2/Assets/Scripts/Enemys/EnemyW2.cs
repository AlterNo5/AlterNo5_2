﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyW2 : MonoBehaviour
{
    public HealthManager healthManager;
    public SphereCollider sCollider;
    Animator player_Anim;
    Animator self_Anim;
    EnemyMovementAB isMoving;
    AudioSource DamagedPlayer;
    public AudioSource MaliDaño;
    public AudioSource ScottDaño;
    public AudioSource SanjinDaño;
    public AudioSource HongoMuerte;

    private void Start()
    {
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        self_Anim = GetComponent<Animator>();
        isMoving = GetComponent<EnemyMovementAB>();
        if (isMoving != null)
        {
            self_Anim.SetBool("Moving", true);
        }
        sCollider = GetComponent<SphereCollider>();

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
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            healthManager.ReduceHealth();
            healthManager.UpdateLives();
            player_Anim = other.gameObject.GetComponentInChildren<Animator>();
            player_Anim.SetTrigger("Damage");

            if (!DamagedPlayer.isPlaying)
            {
                DamagedPlayer.Play();
            }

            if (healthManager.vidaActual <= 0)
            {
                player_Anim.SetBool("Dead", true);
                healthManager.Muerte();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bullet")
        {
            self_Anim.SetBool("Death", true);
            sCollider.enabled = false;
            if (isMoving != null)
            {
                Destroy(gameObject.GetComponent<EnemyMovementAB>());
            }
            if (!HongoMuerte.isPlaying)
            {
                HongoMuerte.Play();
            }

            Stage.allMushroomAlive = false;
        }
    }

}
