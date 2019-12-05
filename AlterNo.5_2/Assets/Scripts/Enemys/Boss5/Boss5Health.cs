using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{

    public class Boss5Health : MonoBehaviour
    {

        public float healthPoints;
        public Boss5Attacks bossAttacks;
        public Animator self_Anim;

        // Start is called before the first frame update
        void Start()
        {
            self_Anim = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Arma")
            {
                healthPoints -= 1;
                self_Anim.SetTrigger("Damage");
                if (healthPoints <= 0)
                {

                }
                else
                {
                bossAttacks.atk3Start = true;

                }

            }
        }
    }
}
