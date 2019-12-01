using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Project.Player
{


    [RequireComponent(typeof(Gun))]

    public class InputGun : MonoBehaviour
    {
        private Gun m_gun;
        public Animator player_anim;
        public bool withgun = false;
        public bool playingAnim = false;
        Animator gun_anim;
        public AudioSource WeaponN1;
        public AudioSource WeaponN2;
        public AudioSource WeaponN3;
        public AudioSource WeaponN4;
        public AudioSource WeaponN5;
        AudioSource WeaponUse;

        // Start is called before the first frame update
        void Start()
        {
            m_gun = GetComponent<Gun>();

            PlayerPrefs.SetInt("Arma_Partida1", 0);
            PlayerPrefs.SetInt("Arma_Partida2", 0);
            PlayerPrefs.SetInt("Arma_Partida3", 0);

            gun_anim = GetComponentInChildren<Animator>();

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                WeaponUse = WeaponN1;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                WeaponUse = WeaponN2;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                WeaponUse = WeaponN3;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                WeaponUse = WeaponN4;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                WeaponUse = WeaponN5;
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetButtonDown("Fire1") && withgun == true && playingAnim == false)
            {
                player_anim.SetTrigger("Shoot");
                Invoke("playAnimation", 50f * Time.deltaTime);
                

            }
        }

        public void OnTriggerEnter(Collider other)
        {


            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Arma_Partida1") == 1)
            {
                player_anim = GameObject.FindObjectOfType<AnimationEvents>().gameObject.GetComponent<Animator>();
                withgun = true;
            }
            else if (PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Arma_Partida2") == 1)
            {
                player_anim = GameObject.FindObjectOfType<AnimationEvents>().gameObject.GetComponent<Animator>();
                withgun = true;
            }
            else if (PlayerPrefs.GetInt("Save3") == 1 && PlayerPrefs.GetInt("Arma_Partida3") == 1)
            {
                player_anim = GameObject.FindObjectOfType<AnimationEvents>().gameObject.GetComponent<Animator>();
                withgun = true;
            }

            if (other.tag == "Player")
            {
                player_anim = other.GetComponent<Animator>();
                withgun = true;
            }
        }

        public void playAnimation()
        {
            if (playingAnim == false)
            {
                gun_anim.SetTrigger("Activate");
                playingAnim = true;
                if (!WeaponUse.isPlaying)
                {
                    WeaponUse.Play();
                }
            }
        }
    }
}
