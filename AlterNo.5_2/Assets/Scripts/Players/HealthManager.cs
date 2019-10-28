using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    // el script esta en la imagen de vidas de la UI
    public  int vidaActual;
    UIManager uiManager;
    public Sprite [] vidas_n_1;
    public Sprite[] vidas_n_2;
    public Sprite[] vidas_n_3;
    public Sprite[] vidas_n_5;
    public Image vidasImagen;
    public int nivel;
   

   
    void Awake()
    {

        SetLivesNivel(nivel);
    }

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        UpdateLives();
    

    }


    public void SetLivesNivel(int nivel)
    {       
        switch (nivel)
        {
            case 1:
                vidaActual = 4;            
                
                break;
            case 2:
                vidaActual= 6;              
                break;
            case 3:
                vidaActual = 8;              
                break;
            case 4:
                vidasImagen.enabled = false;
               
                break;
            case 5:
                vidaActual = 10;            
                break;
        }
    }

    public void UpdateLives()
    {
        switch (nivel )
        {
            case 1:
                vidasImagen.sprite = vidas_n_1[vidaActual];
                break;
            case 2:
                vidasImagen.sprite = vidas_n_2[vidaActual];
                break;
            case 3:
                vidasImagen.sprite = vidas_n_3[vidaActual];
                break;
            case 5:
                vidasImagen.sprite = vidas_n_5[vidaActual];
                break;

        }
    }

    public void ReduceHealth()
    {
        vidaActual = vidaActual - 1;
    }
   
    public void RestaurarVida()
    {
        switch (nivel)
        {
            case 1:
                if(vidaActual == 4 || vidaActual ==  3)
                {                   
                    vidaActual = 4;
                }
                else
                {
                    vidaActual = vidaActual + 2;
                }
              
                break;
            case 2:
                if (vidaActual == 6 || vidaActual == 5)
                {                 
                    vidaActual = 6;
                }
                else
                {
                    vidaActual = vidaActual + 2;
                }
               
                break;
            case 3:
                if (vidaActual == 8 || vidaActual == 7)
                {
                   
                    vidaActual = 8;
                }
                else
                {
                    vidaActual = vidaActual + 2;
                }
                break;
            case 5:
                if (vidaActual == 10 || vidaActual == 9)
                {                  
                    vidaActual = 10;
                }
                else
                {
                    vidaActual = vidaActual + 2;
                }
                break;
        }      
    }

    public void Muerte()
    {
        if (vidaActual == 0)
        {
            Invoke("LoadSceneDelay", 1.5f);
        }

    }

    
    public void LoadSceneDelay()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);           // llama a la escena de inicio
    }

   

}
