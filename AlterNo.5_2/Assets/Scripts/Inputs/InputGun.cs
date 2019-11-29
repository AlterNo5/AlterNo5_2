using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Gun))]

public class InputGun : MonoBehaviour
{
    private Gun m_gun;
    Animator player_anim;
    public bool withgun = false;
    public bool playingAnim = false;
    public Animator gun_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_gun = GetComponent<Gun>();
        gun_anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && withgun == true && playingAnim == false)
        {
            player_anim.SetTrigger("Shoot");
            Invoke("playAnimation", 50f * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            player_anim = other.GetComponent<Animator>();
            withgun = true;
        }
    }

    public void playAnimation()
    {
        if (playingAnim == false)
        {
            gun_anim.SetTrigger("Activate");
            playingAnim = true;
        }
    }
}


