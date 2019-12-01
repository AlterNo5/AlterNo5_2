using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{

    public class AnimationEventsPlayer : MonoBehaviour
    {        
        public PlayerInput m_playerInput;
        public PlayerState m_playerState;
        public Jump jumpController;

        //public EnemyStatus m_enemyStatus;
        public Animator enemy_anim;

        public void Start()
        {
            jumpController = GetComponentInParent<Jump>();
            m_playerInput = GetComponentInParent<PlayerInput>();
            m_playerState = GetComponentInParent<PlayerState>();
        }

        public void Jump()
        {
            jumpController.playerRB.velocity = Vector3.up * jumpController.jumpForce;
        }

        public void Fall()
        {
            m_playerState.doingAnimation = true;
        }

        public void endAnimation()
        {
            m_playerState.doingAnimation = false;
        }

    }
}