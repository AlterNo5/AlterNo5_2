using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public Animator enemy_anim;
    public float HitPoints;
    //private SkinnedMeshRenderer skin;
    //public GameObject DeathParticles;
    //public GameObject deathThing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HitPoints <= 0)
        {
            //if(deathThing == null)
            //{
            //    deathThing = Instantiate(DeathParticles, new Vector3(transform.position.x, transform.position.y + 1f), gameObject.transform.rotation);
            //    deathThing.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //    skin = GetComponentInChildren<SkinnedMeshRenderer>();
            //    skin.enabled = false;
            //}

            //if (!deathThing.GetComponentInChildren<ParticleSystem>().IsAlive())
            //{
            //    Destroy(gameObject.transform.parent.gameObject);
            //}
            BossDeath.bossIsDeath = true;
            //Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
