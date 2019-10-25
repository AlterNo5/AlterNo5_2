using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    Crafteo objetoJabon;
    Crafteo objetoGota;
    Crafteo objetoArma;
    HealthManager healthManager;
   
    public Transform spawnPointPersonaje_transf;
    public GameObject arma_transf;
    public GameObject player_transform;
    

    private void Start()
    {
        //player_transform= GameObject.Find("Personaje(Clone)").GetComponent<GameObject>();
        //arma_transf = GameObject.Find("Arma").GetComponent<GameObject>();

        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
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
            objetoJabon = GetComponent<Crafteo>();

            objetoJabon.Jabon();                              // manda a llamar el método Jabon de la clase Crafteo
            Destroy(other.gameObject);
            
        }

        if(other.tag == "GotaAgua")                             // si el PLAYER colisiona con una gota de agua
        {
            objetoGota = GetComponent<Crafteo>();
            objetoGota.Gota();                                // manda a llamar el método Gota de la clase Crafteo
            Destroy(other.gameObject);
        }

        if(other.tag =="Arma")                                // si el PLAYER colisiona con un arma
        {
           
            objetoArma = GetComponent<Crafteo>();
            objetoArma.Arma();                                // manda a llamar el método Arma de la clase Crafteo


            //arma_transf.SetParent(player_transform);               // pone el arma como hijo del PLAYER
            //arma_transf.SetPositionAndRotation(spawnPointPersonaje_transf.position, spawnPointPersonaje_transf.rotation);      // coloca el arma en una posición y rotación
           
        }


    }
}
