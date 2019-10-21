using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Gun))]

public class InputGun : MonoBehaviour
{
    private Gun m_gun;
    public bool withgun = false;
  
    


    // Start is called before the first frame update
    void Start()
    {
        m_gun = GetComponent<Gun>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && withgun == true)
        {
            m_gun.Shoot();
        }
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            withgun = true;
        }


    }
}


