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

    public int nivel;

  
    private void Start()
    {
     
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
       // textoCantidad_ObjDef.text = "x" + objeDefensa;
    }

}
