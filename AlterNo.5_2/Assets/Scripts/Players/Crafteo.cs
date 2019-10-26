using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafteo : MonoBehaviour
{
    public int objeto_creado = 0;

    public int sumaObjetos;
    public int Num_jabones = 0;
    public int Num_gotasAgua = 0;
    public int arma = 0;
    public int obj_Defensa = 0;
    public bool mali = true;
    public int armaCreada;
 
    UIManager _uiManager;
  
   

   
    void Start()
    {
    
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager.nivel == 2)
        {
            obj_Defensa = 4;
           
            _uiManager.UpdateArma(2);
            _uiManager.UpdateObjetoDefensa_Mali(obj_Defensa);
        }

        if (_uiManager != null)
        {
            _uiManager.UpdateJabon(Num_jabones);
            _uiManager.UpdateGotasAgua(Num_gotasAgua);
           
            
                              
        }
    }

    void Update()
    {
        //StartCoroutine("Esperar");
        obj_Defensa = Fabricar_objeto_defensa(Num_jabones, Num_gotasAgua);
        _uiManager.UpdateObjetoDefensa_Mali(obj_Defensa);

    }

    // **************  Método Jabon *********************
    public void Jabon()
    {
        
            Num_jabones = Num_jabones + 1;  
       _uiManager.UpdateJabon(Num_jabones);       // suma jabones y los manda a la clase uiManager
    }

    // *************  Método Gota  *********************
    public void Gota()
    {    
           Num_gotasAgua = Num_gotasAgua + 1;           
        _uiManager.UpdateGotasAgua(Num_gotasAgua);      // suma las gotas y las manda a la clase uiManager    
    }

    // *************  Método Arma  *********************
    public void Arma()
    {
        if(_uiManager.nivel == 2)
        {
            arma = arma + 4;
        }
        else
        {
            arma = arma + 1;
        }
                                 
        _uiManager.UpdateArma(arma);                    
       
    }
    // *************  Fabricar Arma  *****************************
    public int Fabricar_Arma(int matA)
    {
        Num_gotasAgua = matA;
        if (Num_jabones == 0 & Num_gotasAgua == 1)
        {
            Num_gotasAgua = 0;

            armaCreada = armaCreada + 4;
            _uiManager.UpdateGotasAgua(Num_gotasAgua);
        }
        return armaCreada;
    }

    //  **************  Método Fabricar objeto defensa  *************
    public int Fabricar_objeto_defensa(int crafJabon, int crafGotas)
    {
        Num_jabones = crafJabon;
        Num_gotasAgua = crafGotas;
        if (_uiManager.nivel == 1 || _uiManager.nivel == 5)
        {
            _uiManager.jabonImage.enabled = true;
            _uiManager.textoCantidad_Jabon.enabled = true;

            if (mali == true)   
            {
                if (Num_jabones == 1 & Num_gotasAgua == 1)
                {
                    Num_jabones = 0;
                    Num_gotasAgua = 0;

                    objeto_creado = 1;


                    _uiManager.UpdateJabon(Num_jabones);
                    _uiManager.UpdateGotasAgua(Num_gotasAgua);
                }
                else if (Num_jabones == 1 & Num_gotasAgua == 2) 
                {
                    Num_jabones = 0;
                    Num_gotasAgua = 1;

                    objeto_creado = 1;


                    _uiManager.UpdateJabon(Num_jabones);
                    _uiManager.UpdateGotasAgua(Num_gotasAgua);
                }
            }
            else if (mali == false & Num_jabones == 1 & Num_gotasAgua == 2)
            {
                Num_jabones = 0;
                Num_gotasAgua = 0;

                objeto_creado = 1;


                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);
            }
        }
        else if(_uiManager.nivel == 3)
        {
            _uiManager.jabonImage.enabled = false;
            _uiManager.textoCantidad_Jabon.enabled = false;
           
            if( Num_gotasAgua == 3)
            {
                Num_jabones = 0;
                Num_gotasAgua = 0;

                objeto_creado = 1;

                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);               
            }
        }
        else if (_uiManager.nivel == 2)
        {
            
            if (Num_jabones == 1)
            {
                Num_jabones = 0;
                objeto_creado = objeto_creado+ 4;
                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);
            }
        }
        return objeto_creado;
    }

   


    //  ************ Método Esperar  *******************
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5);             // esperar tantos segundos para ejecutarse una acción
    }
}
