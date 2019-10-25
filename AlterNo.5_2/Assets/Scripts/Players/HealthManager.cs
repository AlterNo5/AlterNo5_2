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
   

    // Start is called before the first frame update
    void Awake()
    {

        SetLivesNivel(nivel);
    }

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
      
    }


    public void SetLivesNivel(int nivel)
    {
        
        switch (nivel)
        {
            case 1:
                vidaActual = 4;
                vidasImagen.sprite = vidas_n_1[vidaActual];
                break;
            case 2:
                vidaActual= 6;
                vidasImagen.sprite = vidas_n_2[vidaActual];
                break;
            case 3:
                vidaActual = 8;
                vidasImagen.sprite = vidas_n_3[vidaActual];
                break;
            
            case 5:
                vidaActual = 10;
                vidasImagen.sprite = vidas_n_5[vidaActual];
                break;

        }
    }


    public void ReduceHealth()
    {
        vidaActual = vidaActual - 1;
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
    //  falta arreglar, se sale del array
    public void RestaurarVida()
    {
        vidaActual = vidaActual + 2;
        switch (nivel)
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
    

    

    public void LoadSceneDelay()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);           // llama a la escena de inicio
    }

    public void Muerte()
    {
        if(vidaActual == 0)
        {
            Invoke("LoadSceneDelay", 1.5f);
        }
       

        

    }

}
