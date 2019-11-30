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

    public LayerMask mask;

    private GameObject m_target;
    int i;
    public Animator m_anim;
    private Vector3 m_destinatedMove;

    private float m_countChange = 0f;
    private float m_timeToChange;
    private bool m_inAttackRange;
    private bool focus = false;
    public float speed;
    
    private Vector3[] m_Paths;
    private bool inPlane = true;
    private int planePosition;
    // Start is called before the first frame update
    void Start()
    {
        m_myStateMachine.InitStateMachine(EnterIdle, UpdateIdle, (int)BossBallStates.Idle);
        speed = 5;  
        m_anim = this.gameObject.transform.GetChild(2).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlane)
        {
            planePosition = 5;
        }
        else if (!inPlane)
        {
            planePosition = -5;
        }

        m_myStateMachine.UpdateStateMachine();
        RaycastHit hit;

        

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Player"))
            {
                m_target = hit.transform.gameObject;
                Debug.DrawLine(transform.position, Vector3.forward, Color.red);
                Debug.Log("I see you sponge bob");
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



    public void AttackRange(bool b)
    {
        m_inAttackRange = b;
    }

    #region Idle

    private void EnterIdle()
    {
        m_timeToChange = 1.5f;
        Debug.Log("IDLE");

    }
    private void UpdateIdle()
    {
        m_countChange += Time.deltaTime;

            if (m_countChange >= m_timeToChange)
            {
                ChangeState(BossBallStates.Move);
            }
        
    }
   
    private void ExitIdle()
    {
        speed += 4;
    }
    #endregion

    #region Move
    private void EnterMove()
    {
        Debug.Log("move");
        
        int Randomx;
        int Randomy;
        m_Paths = new Vector3[3];
      for(i = 0; i < 3; i++)
        {
            Randomx = UnityEngine.Random.Range(-11, -23);
            Randomy = UnityEngine.Random.Range(-8, 0);
            m_Paths[i] = new Vector3(Randomx, Randomy, planePosition);
           
        }
        i = 0;
    }
    private void UpdateMove()
    {
        m_destinatedMove = m_Paths[i];
        if (m_target == null)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Paths[i], Time.deltaTime * speed);
            Debug.Log("");
        }
        else if (m_target != null && !focus)
        {
            i = 3;
            m_Paths[i] = new Vector3(m_target.transform.position.x, m_target.transform.position.y, planePosition);
            focus = true;
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }

        if (transform.position.Equals(m_Paths[i]) && i<=2)
        {
            i++;

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
        
    }
    private void UpdateAttack()
    {
       

    }

    private void ExitAttack()
    {
        
        
    }
    #endregion
}
