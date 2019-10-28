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
    Canvas uIManager;


    private void Start()
    {
      if(nivel == 4)
        {

            uIManager = GameObject.Find("Canvas").GetComponent<Canvas>();
            uIManager.enabled = false;
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
       
        textoCantidad_MatB.text = "x " + currentMatB;
       
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
       
        textoCantidad_MatA.text = "x " + currentMatA;      
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
    public void UpdateObjetoDefensa_Mali(int objeDefensa)
    {      
        if(objeDefensa >=1)
        {
            objetoDefensaImage.sprite = objetoDefensa[1];
        }
        else
        {
            objetoDefensaImage.sprite = objetoDefensa[objeDefensa];
        }
       
        textoCantidad_ObjDef.text = "x" + objeDefensa;
    }

    

    
}
