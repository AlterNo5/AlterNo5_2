using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{


    public class Jump : MonoBehaviour
    {
        public Rigidbody playerRB;
        public Animator anim;
        public float jumpForce = 5f;
        public float fallForce = 2.5f;
        public Transform leftBound;
        public Transform rightBound;
        bool rayCenter;
        bool rayLeft;
        bool rayRight;

        public AudioSource JumpAudio;
        

        PlayerInput playerInput;
        PlayerState m_playerState;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponentInChildren<Animator>();
            playerInput = GetComponent<PlayerInput>();
            playerRB = GetComponentInChildren<Rigidbody>();
            m_playerState = GetComponent<PlayerState>();

            

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") && m_playerState.enTierra)
            {

                if (!JumpAudio.isPlaying)
                {
                    JumpAudio.Play();
                }
                m_playerState.doingAnimation = true;
                anim.SetTrigger("Jump");
                //PlayerState.enTierra = false;
            }
            if (playerRB.velocity.y < 0)
            {
                playerRB.velocity += Vector3.up * Physics.gravity.y * (fallForce - 1) * Time.deltaTime;
            }
            if (playerInput.vertical == -1 && m_playerState.enTierra == false)
            {
                playerRB.velocity += Vector3.up * Physics.gravity.y * (fallForce * 2) * Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            Debug.DrawLine(transform.position, transform.position - (transform.up * 1f), Color.green);
            RaycastHit raycastCenter;
            Physics.Raycast(new Vector3(transform.position.x,transform.position.y +10, transform.position.z), -transform.up, out raycastCenter, 1f);
            if (raycastCenter.collider)
            {
                if (raycastCenter.transform.tag == "Plataformas")
                {
                    rayCenter = true;
                }
                Debug.Log(raycastCenter.transform.tag);
            }
            else
            {
                rayCenter = false;
            }

            Debug.DrawLine(leftBound.position, leftBound.position - (leftBound.up * 0.2f), Color.red);
            RaycastHit raycastLeft;
            Physics.Raycast(leftBound.position, -leftBound.up, out raycastLeft, 0.2f);
            if (raycastLeft.collider)
            {
                if (raycastLeft.transform.tag == "Plataformas")
                {
                    rayLeft = true;
                }
                Debug.Log(raycastLeft.transform.tag);
            }
            else
            {
                rayLeft = false;
            }

            Debug.DrawLine(rightBound.position, rightBound.position - (rightBound.up * 0.2f), Color.blue);
            RaycastHit raycastRight;
            Physics.Raycast(rightBound.position, -rightBound.up, out raycastRight, 0.2f);
            if (raycastRight.collider)
            {
                if (raycastRight.transform.tag == "Plataformas")
                {

                    rayRight = true;
                }
                Debug.Log(raycastRight.transform.tag);
            }
            else
            {
                rayRight = false;
            }

            if (m_playerState.direction == PlayerState.lookDirection.RIGHT && rayLeft || rayCenter)
            {

                m_playerState.enTierra = true;
            }
            else if (m_playerState.direction == PlayerState.lookDirection.LEFT && rayRight || rayCenter)
            {
                m_playerState.enTierra = true;
            }
            else if (m_playerState.direction == PlayerState.lookDirection.NONE && rayLeft || rayCenter || rayRight)
            {
                m_playerState.enTierra = true;
            }
            else
            {
                m_playerState.enTierra = false;                
            }

            if (m_playerState.enTierra)
            {
                anim.SetBool("onAir", false);
            } else
            {
                anim.SetBool("onAir", true);
            }
        }



        //private void OnCollisionEnter(Collision collision)
        //{
        //    Debug.Log("Points colliding: " + collision.contacts.Length);
        //    Debug.Log("Normal: " + collision.contacts[0].normal);

        //    if (collision.contacts[0].normal == Vector3.up)
        //    {
        //        playerState.enTierra = true;
        //    }
        //}

        //private void OnCollisionExit(Collision collision)
        //{
        //    playerState.enTierra = false;
        //}
    }
}
