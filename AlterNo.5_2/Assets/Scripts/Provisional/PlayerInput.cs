using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Project.Player
{

    public class PlayerInput : MonoBehaviour
    {
        public static float horizontal;
        public float vertical;
        public bool attack1;
        PlayerState playerState;
        public AudioSource Walking_N1Audio;
        public AudioSource Walking_N2Audio;
        public AudioSource Walking_N3Audio;
        public AudioSource Walking_N4Audio;
        public AudioSource Walking_N5Audio;
        AudioSource WalkingAudio;

        // Start is called before the first frame update
        void Start()
        {
            playerState = GetComponent<PlayerState>();
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                WalkingAudio = Walking_N1Audio;
            } 
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                WalkingAudio = Walking_N2Audio;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                WalkingAudio = Walking_N3Audio;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                WalkingAudio = Walking_N4Audio;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                WalkingAudio = Walking_N5Audio;
            }


        }

        // Update is called once per frame
        public void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            if (horizontal < 0 && playerState.enTierra)
            {
                playerState.direction = PlayerState.lookDirection.LEFT;
                if (!WalkingAudio.isPlaying)
                {
                    WalkingAudio.Play();
                }

            }
            else if (horizontal > 0 && playerState.enTierra)
            {
                playerState.direction = PlayerState.lookDirection.RIGHT;
                if (!WalkingAudio.isPlaying)
                {
                    WalkingAudio.Play();
                }
            }
            vertical = Input.GetAxis("Vertical");
        }
    }

}
