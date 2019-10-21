using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public InputHandler m_input;
    private Animator anim;
    private Vector2 inputMovement;

    public float m_speed = 5.0f;
    public float m_speed_rotation = 200;
    public float x, y;
   


    void Start()
    {
        anim = GetComponent<Animator>();
    }


   
    private void Update()
    {

        if (m_input.tag == "Player")
        {
            inputMovement = m_input.GetInput;


            anim.SetFloat("VelocidadX", inputMovement.x);
            anim.SetFloat("VelocidadY", inputMovement.y);

            transform.Rotate(0, inputMovement.x * Time.deltaTime * m_speed_rotation, 0);
            transform.Translate(0, 0, inputMovement.y * Time.deltaTime * m_speed);


        }

        if (m_input.tag == "Bullet")
        {
            UpdateInput(m_input.GetInput);

            
        }
    }

    void UpdateInput(Vector2 input)
    {
        float horizontalInput = input.x;
        float verticalInput = input.y;

        transform.Translate(Vector3.left * Time.deltaTime * m_speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * m_speed * verticalInput);
    }


    
}

    
   

   

