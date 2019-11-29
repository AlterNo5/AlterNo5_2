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

public class BossBall : MonoBehaviour
{
    private FSM m_myStateMachine = new FSM();

    private NavMeshAgent m_agent;

    public GameObject m_target;

    public Animator m_anim;
    private Vector3 m_destinatedMove;
    private Vector3 m_actualPosition;
    private float m_countChange = 0f;
    private float m_timeToChange;
    private bool m_inAttackRange;
    private bool focus = false;

    // Start is called before the first frame update
    void Start()
    {
        m_myStateMachine.InitStateMachine(EnterIdle, UpdateIdle, (int)BossBallStates.Idle);
        m_agent = GetComponent<NavMeshAgent>();
        m_anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_myStateMachine.UpdateStateMachine();
        if (m_myStateMachine.GetCurrentState == (int)BossBallStates.Move
            || m_myStateMachine.GetCurrentState == (int)BossBallStates.Follow)
        {
            float value = m_agent.velocity.sqrMagnitude;
            m_anim.SetFloat("Movement", value);
        }
        else
        {
            m_anim.SetFloat("Movement", 0);
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



    public void SetTarget(BossBall v)
    {
   
    }

    public void AttackRange(bool b)
    {
        m_inAttackRange = b;
    }

    #region Idle

    private void EnterIdle()
    {
       

    }
    private void UpdateIdle()
    {

    }
   




    private void ExitIdle()
    {
       
    }
    #endregion

    #region Move
    private void EnterMove()
    {
      

    }
    private void UpdateMove()
    {
    
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
