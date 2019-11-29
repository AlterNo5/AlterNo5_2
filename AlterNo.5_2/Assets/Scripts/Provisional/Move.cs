using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{

    public class Move : MonoBehaviour
    {
        public float speed;
        public float m_turnSpeed;
        public Animator anim;
        private PlayerState m_PlayerDirection;
        public GameObject m_PlayerModel;
        // Start is called before the first frame update
        private void Start()
        {
            m_PlayerDirection = GetComponent<PlayerState>();
            anim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_PlayerDirection.direction == PlayerState.lookDirection.LEFT)
            {
                Quaternion target = Quaternion.Euler(0, 270, 0);
                m_PlayerModel.transform.rotation = Quaternion.Slerp(m_PlayerModel.transform.rotation, target, m_turnSpeed*Time.deltaTime);
            }
            if (m_PlayerDirection.direction == PlayerState.lookDirection.RIGHT)
            {
                Quaternion target = Quaternion.Euler(0, 90, 0);
                m_PlayerModel.transform.rotation = Quaternion.Slerp(m_PlayerModel.transform.rotation, target, m_turnSpeed * Time.deltaTime);
            }

            Debug.Log(m_PlayerDirection.direction);
            if(m_PlayerDirection.doingAnimation == false)
            {
                anim.SetFloat("MovementSpeed", Mathf.Abs(PlayerInput.horizontal));
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + PlayerInput.horizontal * speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }             
            
        }
    }
}
