using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{

    public float speed = 1.0f;
    public Transform player;
    public Vector3 playerPos;
    public Vector3 playercurrentDir;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCollisionDetection>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos == new Vector3(0,0,0) && playercurrentDir == new Vector3(0, 0, 0))
        {
            playerPos = player.position - transform.position;
            playercurrentDir = Vector3.RotateTowards(transform.forward, playerPos, speed * Time.deltaTime, 0.0f);
        }        

        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(playercurrentDir);
    }
}
