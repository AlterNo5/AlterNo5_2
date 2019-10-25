using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionDetection : MonoBehaviour
{
    HealthManager healthManager;

    private void Start()
    {
         healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        
    }

    //  *************  Método LoadSceneDelay  *****************
    public void LoadSceneDelay()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);           // llama a la escena de inicio
    }

    //  **************  Método OnTriggerEnter  ******************
    public void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Player")                
        {
            healthManager.ReduceHealth();
            
                                      
            Destroy(this.gameObject);               // se destruye el enemigo

            healthManager.Muerte();     
        }

        //if(other.tag == "Bullet")                    
        //{
        //    Destroy(other.gameObject);
        //    Destroy(this.gameObject);
        //}
    }
}
