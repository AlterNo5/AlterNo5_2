using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{

    public float speed = 1.0f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDir = player.position - transform.position;
        Vector3 playercurrentDir = Vector3.RotateTowards(transform.forward, playerDir, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(playercurrentDir);
    }
}
