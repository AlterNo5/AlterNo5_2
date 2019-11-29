using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 1f;
    GameObject player;
    GameObject playerLock;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (playerLock == null)
        {
            playerLock = GameObject.FindGameObjectWithTag("Target");
        }
    }

    void Update()
    {

        Vector3 playerDir = player.transform.position - transform.position;
        Vector3 playercurrentDir = Vector3.RotateTowards(transform.forward, playerDir, rotationSpeed * Time.deltaTime, 360f);

        transform.rotation = Quaternion.LookRotation(playercurrentDir);
        transform.position = Vector3.MoveTowards(transform.position, playerLock.transform.position, speed);
    }
}
