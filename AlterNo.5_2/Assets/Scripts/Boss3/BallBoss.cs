using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public enum BossBallStates
{
    Idle = 0,
    Move = 1,
    Follow = 2,
    Attack = 3
}

public class BallBoss : MonoBehaviour
{
    private FSM m_myStateMachine = new FSM();


    private int shoots=5;
    private GameObject m_target;
    private GameObject Player;
    public GameObject EnergyBall;
    bool attacking;
    public Animator m_anim;
    private Vector3 m_destinatedMove;
    public bool agresiveForm = false;
    private float m_countChange = 0f;
    private float m_timeToChange;
    private bool m_inAttackRange;
    private bool focus = false;
    public float speed;
    private float speed2;
    public bool inPlane = true;
    private float planePosition;
    RaycastHit hit;
    private int Randomx;
    private int Randomy;
    public bool hited;
    public Transform LowLimit;
    public Transform TopLimit;
    private bool inCombat;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LookAt>().enabled = false;
        inCombat = false;

        m_myStateMachine.InitStateMachine(EnterIdle, UpdateIdle, (int)BossBallStates.Idle);
        m_timeToChange = 2f;

        m_anim = this.gameObject.transform.GetChild(1).GetComponent<Animator>();


        Player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x < LowLimit.transform.position.x && Player.transform.position.x > TopLimit.transform.position.x)
        {
            inCombat = true;
            GetComponent<LookAt>().enabled = true;
        }
        else
        {
            GetComponent<LookAt>().enabled = false;
            inCombat =false;
        }

        if (!agresiveForm)
        {
            if (m_anim.GetBool("Transform"))
            {
                agresiveForm = true;
            }
        }
            
        m_myStateMachine.UpdateStateMachine();

        if (inPlane)
        {
            planePosition = -6;
        }
        else if (!inPlane)  
        {
            planePosition = -12;
        }

        
    }
    private void FixedUpdate()
    {

        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawLine(transform.position, hit.transform.position, Color.red);
            if (hit.transform.CompareTag("Player"))
            {

                m_target = hit.transform.gameObject;

            }
            else
            {

                m_target = null;
            }

        }
    }

    private void ChangeState(BossBallStates state)
    {
        if (state != (BossBallStates)m_myStateMachine.GetCurrentState)
        {
            switch (state)
            {
                case BossBallStates.Idle:
                    ChangeNow(EnterIdle, UpdateIdle, state);
                    break;
                case BossBallStates.Move:
                    ChangeNow(EnterMove, UpdateMove, state);
                    break;
                case BossBallStates.Follow:
                    ChangeNow(EnterFollow, UpdateFollow, state);
                    break;
                case BossBallStates.Attack:
                    ChangeNow(EnterAttack, UpdateAttack, state);
                    break;
            }
        }
    }

    public void ChangeNow(Action enter, Action update, BossBallStates state)
    {
        switch ((BossBallStates)m_myStateMachine.GetCurrentState)
        {
            case BossBallStates.Idle:
                m_myStateMachine.ChangeState(enter, update, ExitIdle, (int)state);
                break;
            case BossBallStates.Move:
                m_myStateMachine.ChangeState(enter, update, ExitMove, (int)state);
                break;
            case BossBallStates.Follow:
                m_myStateMachine.ChangeState(enter, update, ExitFollow, (int)state);
                break;
            case BossBallStates.Attack:
                m_myStateMachine.ChangeState(enter, update, ExitAttack, (int)state);
                break;
        }
    }

    public void ChangePlane()
    {
        if (inPlane == true)
        {
            inPlane = false;
        }
        else if (inPlane == false)
        {
            inPlane = true;
        }
    }

    public void AttackRange(bool b)
    {
        m_inAttackRange = b;
    }

    #region Idle

    private void EnterIdle()
    {
        shoots = 5;
       
        if (hited && focus == false)
        {
            ChangeState(BossBallStates.Move);

        }

    }
    private void UpdateIdle()
    {
        Debug.Log("IDLE");

        if (hited)
        {
            ChangeState(BossBallStates.Move);
        }
        
       

        if (inCombat)
        {
            m_countChange += Time.deltaTime;
            if (m_countChange >= m_timeToChange)
            {
                if (Player.transform.position.z != transform.position.z)
                {
                    ChangeState(BossBallStates.Attack);
                }
                else if (Player.transform.position.z == transform.position.z)
                {
                    ChangeState(BossBallStates.Move);
                }
            }
        }
    }
   
    private void ExitIdle()
    {
        if (speed < 8)
        {
            speed += 0.2f;
        }
        m_countChange = 0;

    }
    #endregion

    #region Move
    private void EnterMove()
    {
            
            Randomx = (int) UnityEngine.Random.Range(LowLimit.position.x, TopLimit.position.x);
            Randomy = (int)UnityEngine.Random.Range(LowLimit.position.y, TopLimit.position.y);
        m_destinatedMove = new Vector3(Randomx, Randomy, planePosition);
    
        if (hited && agresiveForm)
        {
            m_timeToChange = 0.1f;
            focus = true;
            attacking = false;
            hited = false;
        }
        else if (hited && focus == false)
        {

            ChangeState(BossBallStates.Idle);
            m_timeToChange = 0.1f;
            focus = true;
            attacking = false;
            hited = false;


        }
        


    }
    private void UpdateMove()
    {
        Debug.Log("IDLE");
        if (hited && agresiveForm)
        {
            m_timeToChange = 0.1f;
            focus = true;
            
        }
        else if (hited && focus==false)
        {
          
            ChangeState(BossBallStates.Idle);
            m_timeToChange = 0.1f;
            focus = true;
            attacking = false;
            hited = false;
        }


        if (!agresiveForm)
        {
            if (m_target == null && focus == false)
            {
                Debug.Log("move1");
                focus = true;
                attacking = false;
                m_destinatedMove = new Vector3(Randomx, Randomy, planePosition);
            }
            else if (m_target != null && focus == false)
            {
                Debug.Log("move2");
                speed2 = speed;
                attacking = true;
                speed2 *= 1.5f;
                m_destinatedMove = new Vector3(m_target.transform.position.x, m_target.transform.position.y, planePosition);
                focus = true;
            }
            if (focus == true)
            {
                if (attacking)
                {
                    transform.position = Vector3.MoveTowards(transform.position, m_destinatedMove, Time.deltaTime * (speed2));
                }
                else if (!attacking)
                {
                    transform.position = Vector3.MoveTowards(transform.position, m_destinatedMove, Time.deltaTime * (speed));
                }
            }
            if (m_inAttackRange)
            {
                m_anim.SetTrigger("Attk");

            }
            if (Vector3.Distance(transform.position, m_destinatedMove) ==0)
            {
                if (attacking)
                {
                    m_timeToChange = 1f;
                }
                else
                {
                    m_timeToChange = 0.2f;
                }
                attacking = false;
                ChangeState(BossBallStates.Idle);
                focus = false;

            }
        }
        
        else if (agresiveForm)
        {
            if (focus == false)
            {
                if (m_inAttackRange || hited)
                {
                    transform.position = Vector3.MoveTowards(transform.position, m_destinatedMove, Time.deltaTime * (speed2));
                }
                else if (!m_inAttackRange)
                {
                    transform.position = transform.position;
                    focus = true;
                    m_timeToChange = 0.5f;
                    m_countChange = 0;
                    ChangeState(BossBallStates.Idle);
                }

                if(transform.position == m_destinatedMove)
                {
                    m_timeToChange = 0.1f;
                    m_countChange = 0;
                    ChangeState(BossBallStates.Idle);
                }
            }
            else if(focus == true)
            {
                if (!hited)
                {
                    m_countChange += Time.deltaTime;
                    if (m_countChange >= m_timeToChange && shoots > 0)
                    {
                        Instantiate(EnergyBall, transform.position, transform.rotation);
                        m_anim.SetTrigger("Attk");
                        m_countChange = 0;
                        shoots -= 1;
                    }

                    if (shoots <= 0)
                    {
                        focus = false;
                        ChangeState(BossBallStates.Idle);
                        m_timeToChange = 3;
                        
                    }
                }
                else if (hited)
                {
                    focus = false;
                    ChangeState(BossBallStates.Idle);
                    m_timeToChange = 0.1f;
                    m_countChange = 0;

                }
               
            }
            
            
        }

    }

        private void ExitMove()
    {
     

    }
    #endregion

    #region Follow
    private void EnterFollow()
    {
        
           
       
    }
    private void UpdateFollow()
    {

       
    }

    private void ExitFollow()
    {
      
    }
    #endregion

    #region Attack
    private void EnterAttack()
    {
        speed = 5;
        
        m_timeToChange = 1f;
        m_countChange = 0;
    }
    private void UpdateAttack()
    {
        Debug.Log(transform.position.z+" "+ Player.transform.position.z);
        if (m_countChange >= m_timeToChange)
        {
            Debug.Log("dISPARA");
            Instantiate(EnergyBall, transform.position, transform.rotation);
            m_countChange=0;
        }
       else if (Player.transform.position.z == transform.position.z)
        {
           
            ChangeState(BossBallStates.Idle);
        }
        m_countChange += Time.deltaTime;

    }

    private void ExitAttack()
    {

        m_countChange = 0;
    }
    #endregion
}
