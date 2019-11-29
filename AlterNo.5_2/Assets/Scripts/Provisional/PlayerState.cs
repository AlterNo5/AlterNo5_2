using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{
    public class PlayerState : MonoBehaviour
    {
        public enum lookDirection
        {
            NONE, LEFT, RIGHT
        }
        public void Start()
        {
            actualHealth = maxHealth;
        }

        public float maxHealth;
        public float actualHealth;
        public lookDirection direction = lookDirection.NONE;
        public bool enTierra;
        public bool doingAnimation = false;



    }
}
