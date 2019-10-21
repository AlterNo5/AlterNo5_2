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

        if (Num_gotasAgua > 4)
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
                                                                //  recibe objetos y devuelve el objeto creado
        int total = Num_gotasAgua + Num_jabones;

        for (int i = 0; i < total; i++)
        {
            if (Num_jabones == 1 & Num_gotasAgua == 1)    // 1 jabon , 1 gota
            {              
                Num_jabones = 0;
                Num_gotasAgua = 0;

                objeto_creado = 1;
                sumaObjetos = sumaObjetos + objeto_creado;
             
                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);
            }
            else if (Num_jabones == 1 & Num_gotasAgua == 3) // 1 jabon, 3 gotas
            {
                Num_jabones = 0;
                Num_gotasAgua = 2;

                objeto_creado = 1;
                sumaObjetos = sumaObjetos + objeto_creado;
              
                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);
            }
            else if(Num_jabones == 1 & Num_gotasAgua == 2) // 1 jabon, 2 gotas
            {                           
                Num_jabones = 0;
                Num_gotasAgua = 1;

                objeto_creado = 1;
                sumaObjetos = sumaObjetos + objeto_creado;

                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);
            }
            else if (Num_jabones == 2 & Num_gotasAgua == 1 ) // 2 jabones, gotas
            {
                Num_jabones = 1;
                Num_gotasAgua = 0;

                objeto_creado = 1;
                sumaObjetos = sumaObjetos + objeto_creado;
              
                _uiManager.UpdateJabon(Num_jabones);
                _uiManager.UpdateGotasAgua(Num_gotasAgua);
            }

            objeto_creado = sumaObjetos;          
        }
        return objeto_creado;
    }


    //  ************ Método Esperar  *******************
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5);             // esperar tantos segundos para ejecutarse una acción
    }
}
