using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    
    public Sprite[] matB;
    public Sprite[] matA;

    public Sprite [] armas;
    public Sprite [] objetoDefensa;

   
    public Image matB_Image;
    public Image matA_Image;
    public Image armaImage;
    public Image objetoDefensaImage;

    public Text textoCantidad_MatB;
    public Text textoCantidad_MatA;
    public Text textoCantidad_ObjDef;
    public Text textoCantidad_arma;

    public int nivel;
    Canvas canvas;


    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        switch(nivel)
        {
            case 2:
                armaImage.sprite = armas[1];
                break;
            case 4:
                 canvas.enabled = false;
                break;
        }

        if (PlayerPrefs.GetInt("ActivoCheckpoint") == 1)
        {
            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {
                UpdateMatA(PlayerPrefs.GetInt("MaterialA_Partida1"));
                UpdateMatB(PlayerPrefs.GetInt("MaterialB_Partida1"));
            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {
                UpdateMatA(PlayerPrefs.GetInt("MaterialA_Partida2"));
                UpdateMatB(PlayerPrefs.GetInt("MaterialB_Partida2"));
            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {
                UpdateMatA(PlayerPrefs.GetInt("MaterialA_Partida3"));
                UpdateMatB(PlayerPrefs.GetInt("MaterialB_Partida3"));
            }
        }
        else
        {
            UpdateMatA(0);
            UpdateMatB(0);
        }



    }

    //  *************  Método UpdateMatB  *********************
    public void UpdateMatB(int currentMatB)
    {
      
        if (currentMatB >= 2)
        {
            matB_Image.sprite = matB[1];

        }
        else
        {
            matB_Image.sprite = matB[currentMatB];
        }
       if(currentMatB == 0)
        {
            textoCantidad_MatB.text = " ";
        }
       else
        {
           
            textoCantidad_MatB.text = "x " + currentMatB;
        }      
    }

    //  *************  Método UpdateMatA  *********************
    public void UpdateMatA(int currentMatA)
    {    
        if (currentMatA >= 2)
        {
            matA_Image.sprite = matA[1];
        }
        else
        {
            matA_Image.sprite = matA[currentMatA];
        }

        if (currentMatA == 0)
        {
            textoCantidad_MatA.text = " ";
        }
        else
        {

            textoCantidad_MatA.text = "x " + currentMatA;
        }


       
    }

    //  *************  Método UpdateArma  *********************
    public void UpdateArma(int arma)
    {
        if(arma >=1)
        {
            armaImage.sprite = armas[1];
        }
        else
        {
            armaImage.sprite = armas[arma];
        }
       
    }

    //  *************  Método UpdateObjetoDefensa *********************
    public void UpdateObjetoDefensa(int objeDefensa)
    {      
        if(objeDefensa >=1)
        {
            objetoDefensaImage.sprite = objetoDefensa[1];
        }
        else
        {
            objetoDefensaImage.sprite = objetoDefensa[objeDefensa];
        }
        if (nivel != 2)
        {
            textoCantidad_ObjDef.enabled = false;
        }
        else
        {
            objetoDefensaImage.sprite = objetoDefensa[1];
            objeDefensa = objeDefensa + 4;
            textoCantidad_ObjDef.enabled = true;
            textoCantidad_ObjDef.text = "x" + objeDefensa;
        }
       
      
    }

    

    
}
