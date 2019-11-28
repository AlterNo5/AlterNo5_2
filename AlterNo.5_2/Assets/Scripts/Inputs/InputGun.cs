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
        PlayerPrefs.SetInt("Arma_Partida1", 0);
        PlayerPrefs.SetInt("Arma_Partida2", 0);
        PlayerPrefs.SetInt("Arma_Partida3", 0);

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

        
        if (PlayerPrefs.GetInt("Save1") == 1 &&  PlayerPrefs.GetInt("Arma_Partida1") == 1)
        {
            withgun = true;
        }
        else if(PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Arma_Partida2") == 1)
        {
            withgun = true;
        }
        else if (PlayerPrefs.GetInt("Save3") == 1 &&  PlayerPrefs.GetInt("Arma_Partida3") == 1)
        {
            withgun = true;
        }

        if (other.tag == "Player")
        {
            withgun = true;
        }


    }
}


