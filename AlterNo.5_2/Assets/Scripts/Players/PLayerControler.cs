using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPhysics))]
public class PLayerControler : MonoBehaviour
{

    public float walkspeed = 8;
    public float runSpeed = 12;
    public float acceleration = 12;
    public float gravity = 20;
    public float jumpHeight = 8;


    private float animationSpeed;
    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;
    private Animator animator;

    // States

    private bool jumping;

    private PlayerPhysics playerPhysics;


    void Start()
    {

        playerPhysics = GetComponent<PlayerPhysics>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        // Input
        float speed = (Input.GetButton("Run")) ? runSpeed : walkspeed;
        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        animationSpeed = IncrementTowards(animationSpeed, Mathf.Abs(targetSpeed), acceleration);
        animator.SetFloat("Speed", animationSpeed);


        if (playerPhysics.movementStopped)
        {
            targetSpeed = 0;
            currentSpeed = 0;
        }


        if (playerPhysics.grounded)
        {
            amountToMove.y = 0;

            if (jumping)
            {
                jumping = false;
                animator.SetBool("Jumping", false);
            }

            // jump
            if (Input.GetButtonDown("Jump"))
            {
                amountToMove.y = jumpHeight;
                jumping = true;
                animator.SetBool("Jumping", true);
            }
        }



        // Set amount to move
        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);

        // face direction
        float moveDir = Input.GetAxisRaw("Horizontal");

        if (moveDir != 0)
        {
            if (moveDir < 0)
            {

                transform.eulerAngles = Vector3.up * 180;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
            }
        }
    }

    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
}
