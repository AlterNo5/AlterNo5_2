using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_HitManager : MonoBehaviour
{
    public int life = 12;
    public BallBoss Boss;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Sword"))
        {
            //codigo para hacer daño al boss

            Boss.hited = true;
            
            life -= 1;
            Debug.Log(life);

            Boss.m_anim.SetTrigger("Hurted");
            if (life <= 6)
            {
                Boss.m_anim.SetBool("Transform",true);
               
            }
            if (life % 3 == 0 && life < 12)
            {
               
                Boss.ChangePlane();
            }
        }
        else if (other.CompareTag("Player")){
            //Codigo para hacer daño al player
        }
    }
        
            
    }

