using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_HitManager : MonoBehaviour
{
    public int life = 12;
    public BallBoss Boss;
    public GameObject SpawnPointPortal;
    public GameObject Portal;
    public AudioSource BossAudio, BossHit;

    void Start()
    {
        BossAudio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Arma"))
        {
            //codigo para hacer daño al boss

            Boss.hited = true;
            
            life -= 1;
            Debug.Log(life);
            if (!BossHit.isPlaying)
            {
                BossHit.Play();
            }

            Boss.m_anim.SetTrigger("Hurted");
            
            if (life % 3 == 0 && life < 12)
            {
                if (life == 6)
                {
                    Boss.m_anim.SetBool("Transform", true);

                }
                else
                {
                    Boss.ChangePlane();
                }
                
            }
            else if (life <= 0)
            {
                Boss.m_anim.SetBool("Death", true);
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<SphereCollider>().isTrigger = false;
                GetComponent<LookAt>().enabled = false;
                Instantiate(Portal, SpawnPointPortal.transform.position, SpawnPointPortal.transform.rotation);

                Invoke("DestroyThis", 3);
            }
        }
        else if (other.CompareTag("Player")){
            //Codigo para hacer daño al player
        }
    }
        void DestroyThis()
    {
        Destroy(this.gameObject);
    }
            
    }

