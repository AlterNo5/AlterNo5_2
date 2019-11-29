using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Com.Project.Player
{

    public class PlayerMovement : MonoBehaviour
    {
        public InputHandler2 playerMove;
        public float speed;
        public Rigidbody playerRB;
        public bool enTierra;

        private void Start()
        {
            playerRB = GetComponent<Rigidbody>();
        }


        // Update is called once per frame
        void Update()
        {
            if (playerMove.horizontal != 0)
            {
                transform.Translate((playerMove.horizontal * speed) * Time.deltaTime, 0, 0);
            }

            if (playerMove.vertical > 0 && enTierra == true)
            {
                playerRB.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
                enTierra = false;
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == ("Suelo") && enTierra == false)
            {
                enTierra = true;
            }
        }
    }
}
