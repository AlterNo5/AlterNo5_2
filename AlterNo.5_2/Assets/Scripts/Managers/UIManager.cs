using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Sprite[] jabones;
    public Sprite[] gotasDeAgua;

    public Sprite [] armas;
    public Sprite [] objetoDefensa;

   
    public Image jabonImage;
    public Image gotaAguaImage;
    public Image armaImage;
    public Image objetoDefensaImage;

    public Text textoCantidad_Jabon;
    public Text textoCantidad_Gotas;
    public Text textoCantidad_ObjDef;
    public Text textoCantidad_arma;

    public int nivel;


    private void Start()
    {
       // armaImage.sprite = armas[1];
    }

    //  *************  Método UpdateJabon  *********************
    public void UpdateJabon(int jabonActual)
    {
      
        if (jabonActual >= 2)
        {
            jabonImage.sprite = jabones[1];

        }
        else
        {
            jabonImage.sprite = jabones[jabonActual];
        }
       
        textoCantidad_Jabon.text = "x " + jabonActual;
       
    }

    //  *************  Método UpdateGotasAgua  *********************
    public void UpdateGotasAgua(int gotasActuales)
    {
     
        if (gotasActuales >= 2)
        {
            gotaAguaImage.sprite = gotasDeAgua[1];

        }
        else
        {
            gotaAguaImage.sprite = gotasDeAgua[gotasActuales];
        }
       
        textoCantidad_Gotas.text = "x " + gotasActuales;
       
       
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
