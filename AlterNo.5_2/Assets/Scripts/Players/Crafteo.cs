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
   // public bool nivel_3 = true;
    UIManager _uiManager;
   // public GameObject jabonGO;
    public SphereCollider colliderJabon;
    public SphereCollider colliderGota;

   
    void Start()
    {
       // jabonGO = GameObject.Find("Jabon");

        colliderJabon = GameObject.Find("Jabon").GetComponent<SphereCollider>();
        colliderGota = GameObject.Find("GotaDeAgua").GetComponent<SphereCollider>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateJabon(Num_jabones);
            _uiManager.UpdateGotasAgua(Num_gotasAgua);
            _uiManager.UpdateArma(arma);                     
        }
    }

    void LateUpdate()
    {
        StartCoroutine("Esperar");
        obj_Defensa = Fabricar_objeto_defensa(Num_jabones, Num_gotasAgua);
       
        _uiManager.UpdateObjetoDefensa_Mali(obj_Defensa);

    }

    // **************  Método Jabon *********************
    public void Jabon()
    {
        Num_jabones = Num_jabones + 1;
      
            _uiManager.UpdateJabon(Num_jabones);       // suma jabones y los manda a la clase uiManager

        if (Num_jabones > 2)
        {
            colliderJabon.enabled = false;           // desactivo el colaider si encuentra más de dos jabones
        }
        
    }

    // *************  Método Gota  *********************
    public void Gota()
    {
        Num_gotasAgua = Num_gotasAgua + 1;
        _uiManager.UpdateGotasAgua(Num_gotasAgua);      // suma las gotas y las manda a la clase uiManager

        if (Num_gotasAgua > 5)
        {
            colliderGota.enabled = false;              // desactiva el colaider por si encuentra más de 4 gotas
        }
    }

    // *************  Método Arma  *********************
    public void Arma()
    {
        arma = arma + 1;                                // suma el arma y las manda a la clase uiManager
        _uiManager.UpdateArma(arma);                    // nota: solo es un arma pero el array tiene dos espacios para el circulo azul vacio
       
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

            if (mali == true)    // 1 jabon , 1 gota
            {
                if (Num_jabones == 1 & Num_gotasAgua == 1)
                {
                    Num_jabones = 0;
                    Num_gotasAgua = 0;

                    objeto_creado = 1;


                    _uiManager.UpdateJabon(Num_jabones);
                    _uiManager.UpdateGotasAgua(Num_gotasAgua);
                }
                else if (Num_jabones == 1 & Num_gotasAgua == 2) // 1 jabon, 3 gotas
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
            Debug.Log("nivel 3");
            if(Num_jabones ==0 & Num_gotasAgua == 3)
            {
                Num_jabones = 0;
                Num_gotasAgua = 0;

                objeto_creado = 1;

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
