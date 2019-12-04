using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Project.Player
{

    public class AnimationEventsPlayer : MonoBehaviour
    {        
        public PlayerInput m_playerInput;
        public PlayerState m_playerState;
        public Jump jumpController;


        
        public AudioSource LandRocas, LandBurbuja, LandMetal, LandEco;
        AudioSource LandAudio;
        //public EnemyStatus m_enemyStatus;
        public Animator enemy_anim;

        public void Start()
        {
            jumpController = GetComponentInParent<Jump>();
            m_playerInput = GetComponentInParent<PlayerInput>();
            m_playerState = GetComponentInParent<PlayerState>();

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                LandAudio = LandBurbuja;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                LandAudio = LandRocas;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                LandAudio = LandMetal;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                LandAudio = LandEco;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                LandAudio = LandMetal;
            }
        }

        public void Jump()
        {
            jumpController.playerRB.velocity = Vector3.up * jumpController.jumpForce;
        }

        public void Fall()
        {
            m_playerState.doingAnimation = true;
            LandAudio.Play();
        }

        public void endAnimation()
        {
            m_playerState.doingAnimation = false;
        }



    }
}