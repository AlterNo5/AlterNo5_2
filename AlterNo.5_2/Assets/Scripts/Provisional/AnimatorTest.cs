using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public float horizontal;
    public Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            m_anim.SetTrigger("Blade");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            m_anim.SetTrigger("Shoot");
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            horizontal = Input.GetAxis("Horizontal");            
        }

        m_anim.SetFloat("MovementSpeed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            m_anim.SetTrigger("Jump");
        }

    }
}
