using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
   
    

    public float speed = 1.0f;
    public Transform player;
    public Vector3 playerPos;
    private float time_life;
    private float born;
    public float time_max;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCollisionDetection>().gameObject.transform;
        born = Time.time;
    }

    void Update()
    {

        if (playerPos == new Vector3(0, 0, 0))
        {
            playerPos = player.position;
            transform.LookAt(playerPos);
        }

        transform.position = transform.position + transform.forward * speed * Time.deltaTime;

        if(time_life >= time_max)
        {
            Destroy(this.gameObject);
        }
        else
        {
            time_life = Time.time - born;
        }

    }
}
