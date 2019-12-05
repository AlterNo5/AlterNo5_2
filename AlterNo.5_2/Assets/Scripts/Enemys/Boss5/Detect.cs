using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{
    public class Detect : MonoBehaviour
    {
        public Boss5Attacks boss;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                boss.player = other.gameObject;
                boss.Invoke("nextAction", 1f);
                Destroy(this);
            }
        }
    }
}
