using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionDetection : MonoBehaviour
{
    Vidas vida;
    
    
    //  *************  Método LoadSceneDelay  *****************
    public void LoadSceneDelay()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);           // llama a la escena de inicio
    }

    //  **************  Método OnTriggerEnter  ******************
    public void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Enemy")                // si el PLAYER colisiona con el enemigo
        {
            vida = GetComponent<Vidas>();

            vida.Vida();                             // se manda a llamar el método Vida de la clase Vidas
            Destroy(other.gameObject);               // se destruye el enemigo
          
            if(vida.vidas == 0)                     // cuando pierde todas las vidas se invoca a la escena de inicio
            {
                Invoke("LoadSceneDelay", 1.5f);
            }          
        }

        if(other.tag == "Bullet")                    
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
