using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionDetection : MonoBehaviour
{
    Crafteo crafteo;
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
        crafteo =  GameObject.Find("Personaje(Clone)"). GetComponent<Crafteo>();      
    }

    private void Update()
    {
        
       
    }

    //  *****************  Método OnTriggerEnter  ***********************
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Restaurador")                         
        {                       
            healthManager.RestaurarVida();
            healthManager.UpdateLives();
            Destroy(other.gameObject);
            
        }

        if (other.tag == "MatB")                             
        {         
            crafteo.AddMatB();          
            Destroy(other.gameObject);           
        }

        if(other.tag == "MatA")                             
        {       
            crafteo.AddMatA();
            
            crafteo.Fabricar_Arma();
            Destroy(other.gameObject);
        }

        if(other.tag =="Arma")                               
        {                
            crafteo.Arma();                               
            arma_transf.SetParent(spawnPointPersonaje_transf);              
            arma_transf.SetPositionAndRotation(spawnPointPersonaje_transf.position, spawnPointPersonaje_transf.rotation);              
        }

        if(other.tag == "Flag")
        {
          
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                                     
        }
    }
}
