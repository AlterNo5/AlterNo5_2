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
            PlayerPrefs.SetInt("ActivoCheckpoint", 0);
            PlayerPrefs.SetInt("MaterialA_Partida1", 0);
            PlayerPrefs.SetInt("MaterialB_Partida1", 0);

            PlayerPrefs.SetInt("MaterialA_Partida2", 0);
            PlayerPrefs.SetInt("MaterialB_Partida2", 0);

            PlayerPrefs.SetInt("MaterialA_Partida3", 0);
            PlayerPrefs.SetInt("MaterialB_Partida3", 0);

        }

        if(other.tag == "Checkpoint")
        {
            
            PlayerPrefs.SetInt("ActivoCheckpoint", 1);
            Debug.Log(PlayerPrefs.GetInt("ActivoCheckpoint"));
            
            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {

                
                PlayerPrefs.SetInt("MaterialA_Partida1", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida1", PlayerPrefs.GetInt("MaterialB_Guardado"));
            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {

                
                PlayerPrefs.SetInt("MaterialA_Partida2", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida2", PlayerPrefs.GetInt("MaterialB_Guardado"));
            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {

                
                PlayerPrefs.SetInt("MaterialA_Partida3", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida3", PlayerPrefs.GetInt("MaterialB_Guardado"));
            }
            Debug.Log(PlayerPrefs.GetInt("MaterialA_Partida1"));

        }
    }
}
