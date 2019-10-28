using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafteo : MonoBehaviour
{
    public int objeto_creado = 0;

   
    public int num_MatB = 0;
    public int num_MatA = 0;
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
            _uiManager.UpdateMatB(num_MatB);
            _uiManager.UpdateMatA(num_MatA);
           
            
                              
        }
    }

    void Update()
    {
        //StartCoroutine("Esperar");
        obj_Defensa = Fabricar_objeto_defensa(num_MatB, num_MatA);
        _uiManager.UpdateObjetoDefensa_Mali(obj_Defensa);

    }

    // **************  Método Jabon *********************
    public void AddMatB()
    {
        
            num_MatB = num_MatB + 1;  
       _uiManager.UpdateMatB(num_MatB);       // suma jabones y los manda a la clase uiManager
    }

    // *************  Método Gota  *********************
    public void AddMatA()
    {    
           num_MatA = num_MatA + 1;           
        _uiManager.UpdateMatA(num_MatA);      // suma las gotas y las manda a la clase uiManager    
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
        num_MatA = matA;
        if (num_MatB == 0 & num_MatA == 1)
        {
            num_MatA = 0;

            armaCreada = armaCreada + 4;
            _uiManager.UpdateMatA(num_MatA);
        }
        return armaCreada;
    }

    //  **************  Método Fabricar objeto defensa  *************
    public int Fabricar_objeto_defensa(int crafMatB, int craftMatA)
    {
        num_MatB = crafMatB;
        num_MatA = craftMatA;
        if (_uiManager.nivel == 1 || _uiManager.nivel == 5)
        {
            _uiManager.matB_Image.enabled = true;
            _uiManager.textoCantidad_MatB.enabled = true;

            if (mali == true)   
            {
                if (num_MatB == 1 & num_MatA == 1)
                {
                    num_MatB = 0;
                    num_MatA = 0;

                    objeto_creado = 1;


                    _uiManager.UpdateMatB(num_MatB);
                    _uiManager.UpdateMatA(num_MatA);
                }
                else if (num_MatB == 1 & num_MatA == 2) 
                {
                    num_MatB = 0;
                    num_MatA = 1;

                    objeto_creado = 1;


                    _uiManager.UpdateMatB(num_MatB);
                    _uiManager.UpdateMatA(num_MatA);
                }
            }
            else if (mali == false & num_MatB == 1 & num_MatA == 2)
            {
                num_MatB = 0;
                num_MatA = 0;

                objeto_creado = 1;


                _uiManager.UpdateMatB(num_MatB);
                _uiManager.UpdateMatA(num_MatA);
            }
        }
        else if(_uiManager.nivel == 3)
        {
            _uiManager.matB_Image.enabled = false;
            _uiManager.textoCantidad_MatB.enabled = false;
           
            if( num_MatA == 3)
            {
                num_MatB = 0;
                num_MatA = 0;

                objeto_creado = 1;

                _uiManager.UpdateMatB(num_MatB);
                _uiManager.UpdateMatA(num_MatA);               
            }
        }
        else if (_uiManager.nivel == 2)
        {
            
            if (num_MatB == 1)
            {
                num_MatB = 0;
                objeto_creado = objeto_creado+ 4;
                _uiManager.UpdateMatB(num_MatB);
                _uiManager.UpdateMatA(num_MatA);
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
