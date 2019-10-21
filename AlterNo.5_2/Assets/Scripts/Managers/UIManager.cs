using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

   
  
    public Sprite [] vidas_n_1;
    public Sprite[] vidas_n_2;
    public Sprite[] vidas_n_3;
    public Sprite[] vidas_n_5;

    public Sprite[] jabones;
    public Sprite[] gotasDeAgua;

    public Sprite [] armas;
    public Sprite [] objetoDefensa;

    public Image vidasImagen;
    public Image jabonImage;
    public Image gotaAguaImage;
    public Image armaImage;
    public Image objetoDefensaImage;

    public Text textoCantidad_Jabon;
    public Text textoCantidad_Gotas;
    public Text textoCantidad_ObjDef;

    // los siguientes métodos actualizan la imagen en la UI siguiente en los arrays correspondientes a cada método

    //  *************  Método UpdateLives  *********************
    public void UpdateLives (int vidasActuales)
    { 
        vidasImagen.sprite = vidas_n_1[vidasActuales];       
    }

    //  *************  Método UpdateJabon  *********************
    public void UpdateJabon(int jabonActual)
    {        
        jabonImage.sprite = jabones[jabonActual];
        textoCantidad_Jabon.text = "x " + jabonActual;
       
    }

    //  *************  Método UpdateGotasAgua  *********************
    public void UpdateGotasAgua(int gotasActuales)
    {     
        gotaAguaImage.sprite = gotasDeAgua[gotasActuales];
        textoCantidad_Gotas.text = "x " + gotasActuales;
       
    }

    //  *************  Método UpdateArma  *********************
    public void UpdateArma(int arma)
    {
        armaImage.sprite = armas[arma];
    }

    //  *************  Método UpdateObjetoDefensa *********************
    public void UpdateObjetoDefensa_Mali(int objeDefensa)
    {      
        objetoDefensaImage.sprite = objetoDefensa[objeDefensa];
        textoCantidad_ObjDef.text = "x" + objeDefensa;
    }

}
