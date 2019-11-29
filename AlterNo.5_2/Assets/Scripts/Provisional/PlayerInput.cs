using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{

    public class PlayerInput : MonoBehaviour
    {
        public static float horizontal;
        public float vertical;
        public bool attack1;
        PlayerState playerState;

        // Start is called before the first frame update
        void Start()
        {
            playerState = GetComponent<PlayerState>();
        }

        // Update is called once per frame
        public void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            if (horizontal < 0 && playerState.enTierra)
            {
                playerState.direction = PlayerState.lookDirection.LEFT;
            }
            else if (horizontal > 0 && playerState.enTierra)
            {
                playerState.direction = PlayerState.lookDirection.RIGHT;
            }
            vertical = Input.GetAxis("Vertical");
        }
    }

}
