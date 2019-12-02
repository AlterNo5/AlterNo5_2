using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public enum KingPlantState
{
    Idle = 0,
    Attack = 1,
    Shoot = 2,
    ReturnToOrigin = 3,
    Scape = 4
    
}

public class KingPlant : MonoBehaviour
{
    public Transform leftLimit;
    public Transform rightLimit;

    private bool m_inCombat;

    private FSM m_myStateMachine = new FSM();

    private NavMeshAgent m_agent;


    private Vector3 m_desiredPosition;

    private GameObject m_Player;

    private int direction;
    private float loops = 4;
    private int shoots;

    public Animator m_anim;

    private Rigidbody rb;
    private float m_Timer = 0;
    private float m_Count = 0;

    public int HitPoints;


    // Start is called before the first frame update
    void Start()
    {
        m_myStateMachine.InitStateMachine(EnterIdle, UpdateIdle, (int)KingPlantState.Idle);
        m_agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(rb.velocity);

        m_myStateMachine.UpdateStateMachine();
        if (m_myStateMachine.GetCurrentState == (int)KingPlantState.Attack
            || m_myStateMachine.GetCurrentState == (int)KingPlantState.ReturnToOrigin)
        {
            float value = m_agent.velocity.sqrMagnitude;
           m_anim.SetFloat("Speed",value); 
        }
        else
        {
            m_anim.SetFloat("Speed",0);  
        }

        if (rb.velocity.y < 0)
        {
            direction =-1;
        }
        else if(rb.velocity.y > 0)
        {
            direction = 1;
        }

    }

    private void ChangeState(KingPlantState state)
    {
        if (state != (KingPlantState) m_myStateMachine.GetCurrentState)
        {
            switch (state)
            {
                case KingPlantState.Idle:
                    ChangeNow(EnterIdle, UpdateIdle, state);
                    break;
                case KingPlantState.Shoot:
                    ChangeNow(EnterShoot, UpdateShoot, state);
                    break;
                case KingPlantState.ReturnToOrigin:
                    ChangeNow(EnterReturnOrigin, UpdateReturnOrigin, state);
                    break;
                case KingPlantState.Attack:
                    ChangeNow(EnterAttack, UpdateAttack, state);
                    break;
            }
        }
    }

    public void ChangeNow(Action enter, Action update, KingPlantState state)
    {
        switch ((KingPlantState) m_myStateMachine.GetCurrentState)
        {
            case KingPlantState.Idle:
                m_myStateMachine.ChangeState(enter, update, ExitIdle, (int) state);
                break;
            case KingPlantState.Shoot:
                m_myStateMachine.ChangeState(enter, update, ExitShoot, (int) state);
                break;
            case KingPlantState.ReturnToOrigin:
                m_myStateMachine.ChangeState(enter, update, ExitReturnOrigin, (int) state);
                break;
            case KingPlantState.Attack:
                m_myStateMachine.ChangeState(enter, update, ExitAttack, (int) state);
                break;
        }
    }



    public void Headbutt(GameObject b)
    {
        m_Player = b;
        
    }

    public void inCombat(bool a)
    {
       
        m_inCombat = a;
    }



    #region Idle


    private void EnterIdle()
    {
      
        m_Timer = 1f;
    }

    private void UpdateIdle()
    {
        Debug.Log("ENTRA IDLE");
        if (m_inCombat)
        {
            Debug.Log("ENTRA combate");
            m_Count += Time.deltaTime;
            if (m_Count >= m_Timer)
            {
                if (loops != 0)
                {
                  
                    ChangeState(KingPlantState.Attack);
                }
                else if (loops == 0)
                {
                      if(transform.position.x != leftLimit.position.x && transform.position.x != rightLimit.position.x)
                        {
                        ChangeState(KingPlantState.ReturnToOrigin);
                        
                        }
                    else
                    {
                        ChangeState(KingPlantState.Shoot);
                    }
                    loops = Mathf.Round(UnityEngine.Random.Range(1f, 4f));

                }
            }
        }
        else if (!m_inCombat)
        {
            
        }

        
    }

    private void ExitIdle()
    {
        m_Count = 0;
     

    }

    #endregion

    #region Shoot

    private void EnterShoot()
    {
        m_Timer = 0.8f;
        shoots = 5;


        if (Vector3.Distance(transform.position, leftLimit.position) < Vector3.Distance(transform.position, rightLimit.position))
        {
            
            transform.rotation = Quaternion.Euler(0, (transform.rotation.y) - (90 * direction), 0);

        }
        else if (Vector3.Distance(transform.position, leftLimit.position) > Vector3.Distance(transform.position, rightLimit.position))
        {
          
            transform.rotation = Quaternion.Euler(0, (transform.rotation.y) + (90 * direction), 0);
        }


        m_anim.SetBool("Attack", true);
       
    }

    private void UpdateShoot()
    {
        m_Count += Time.deltaTime;
       

        if (m_Count >= m_Timer)
        {
            Debug.Log("Dispara?");
            m_Count = 0;
            m_anim.SetTrigger("Shoot");
            shoots -= 1;
            if (shoots<=0)
            {
                ChangeState(KingPlantState.Idle);
            }
        }

       
    }

    private void ExitShoot()
    {
        m_Count = 0;
        m_anim.SetBool("Attack", false);
    }

    #endregion

    #region ReturnOrigin

    public void EnterReturnOrigin()
    {

            if (transform.rotation.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, (transform.rotation.y) + (90 * direction), 0);
                m_desiredPosition = leftLimit.position;
            }
            else if (transform.rotation.y < 0)
            {
                transform.rotation = Quaternion.Euler(0, (transform.rotation.y) - (90 * direction), 0);
                m_desiredPosition = rightLimit.position;
            }
            m_agent.SetDestination(m_desiredPosition);
      
        
        
    }

    public void UpdateReturnOrigin()
    {
        
        if (m_agent.hasPath)
        {
            if (m_agent.isStopped && m_agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                if (m_inCombat)
                {
                    ChangeState(KingPlantState.Shoot);
                }
                else
                {
                    ChangeState(KingPlantState.Idle);
                }
                
            }
        }
        else
        {
            if (!m_agent.pathPending)
            {
                
                ChangeState(KingPlantState.Shoot);
            }
        }
    }

    public void ExitReturnOrigin()
    {
       
    }

    #endregion

    #region Attack

    
    public void EnterAttack()
    {
        Debug.Log("ENTRA ATTACK");
        transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;

       if(Vector3.Distance(transform.position,leftLimit.position) < Vector3.Distance(transform.position, rightLimit.position))
        {
            m_desiredPosition = rightLimit.position;
            transform.rotation = Quaternion.Euler(0, (transform.rotation.y) - (90 * direction), 0);

        }
       else if(Vector3.Distance(transform.position, leftLimit.position) > Vector3.Distance(transform.position, rightLimit.position))
        {
            m_desiredPosition = leftLimit.position;
            transform.rotation = Quaternion.Euler(0, (transform.rotation.y) + (90 * direction), 0);
        }

        m_agent.SetDestination(m_desiredPosition);
       


    }

    public void UpdateAttack()
    {
       
        if (m_agent.hasPath)
        {
            if (m_agent.isStopped && m_agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                loops -= 1;
                ChangeState(KingPlantState.Idle);

            }
        }
        else
        {
            if (!m_agent.pathPending)
            {
                loops -= 1;
                ChangeState(KingPlantState.Idle);
            }
        }

        if (m_Player != null)
        {
           
            m_agent.SetDestination(transform.position);
            m_Player = null;
            m_anim.SetTrigger("Headbutt");
            loops -= 1;


                ChangeState(KingPlantState.Idle);
            
           
            
        }
    }

    public void ExitAttack()
    {

    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            m_inCombat = true;
            m_anim.SetTrigger("Hurted");
            HitPoints -= 1;
            m_anim.SetInteger("Life", HitPoints);
            BossDeath.bossEncounter = true;
            BossDeath.bossIsDeath = false;

            if(HitPoints <= 0)
            {
                m_inCombat = false;
                BossDeath.bossEncounter = false;
                BossDeath.bossIsDeath = true;
            }
        }
    }

}