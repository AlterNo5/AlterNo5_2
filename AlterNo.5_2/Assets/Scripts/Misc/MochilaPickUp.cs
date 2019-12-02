using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaPickUp : MonoBehaviour
{
    public GameObject mochila;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            mochila = GameObject.FindObjectOfType<Arma2>().gameObject;
            mochila.GetComponent<MeshRenderer>().enabled = true;
            mochila.GetComponent<Arma2>().isEquiped = true;
            Destroy(this.gameObject);
        }
    }

}
