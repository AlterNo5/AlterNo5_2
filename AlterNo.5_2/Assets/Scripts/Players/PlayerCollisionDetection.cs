using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    Crafteo craft_objeto;
    HealthManager healthManager;
    UIManager _uiManager;

    public Transform spawnPointPersonaje_transf;
    public Transform arma_transf;
    public Transform player_transform;
    

    private void Start()
    {
        player_transform= GameObject.Find("Personaje(Clone)").GetComponent<Transform>();
        arma_transf = GameObject.Find("Arma").GetComponent<Transform>();


        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        craft_objeto =  GameObject.Find("Personaje(Clone)"). GetComponent<Crafteo>();
       
    }

    private void Update()
    {
        
       
    }

    //  *****************  Método OnTriggerEnter  ***********************
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Restaurador")                         // si el PLAYER colisiona con el restaurador
        {   
           healthManager.RestaurarVida();             // RestaurarVida de la clase Vidas
           Destroy(other.gameObject);                     // destruye el restaurador          
      }

        if (other.tag == "Jabon")                              // si el PLAYER colisiona con el jabon
        {         
            craft_objeto.Jabon();
           
            Destroy(other.gameObject);           
        }

        if(other.tag == "GotaAgua")                             // si el PLAYER colisiona con una gota de agua
        {       
            craft_objeto.Gota();
            Destroy(other.gameObject);
        }

        if(other.tag =="Arma")                                // si el PLAYER colisiona con un arma
        {                
            craft_objeto.Arma();                                // manda a llamar el método Arma de la clase Crafteo
            arma_transf.SetParent(spawnPointPersonaje_transf);               // pone el arma como hijo del PLAYER
            arma_transf.SetPositionAndRotation(spawnPointPersonaje_transf.position, spawnPointPersonaje_transf.rotation);      // coloca el arma en una posición y rotación         
        }
    }
}
