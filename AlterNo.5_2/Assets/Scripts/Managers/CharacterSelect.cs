using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    private GameObject[] CharacterList;
    public GameObject CanvasChange;

    // Will later update number with savestate, right now this is my approach
    private bool Partida1_Selected = false;
    private bool Partida2_Selected = false;
    private bool Partida3_Selected = false;

    public GameObject CanvasPartidas;

    private int Yaconfirmo;

    public GameObject ImagenSanjin1,ImagenScott1, ImagenMali1, ImagenDefault1;
    public GameObject ImagenSanjin2, ImagenScott2, ImagenMali2, ImagenDefault2;
    public GameObject ImagenSanjin3, ImagenScott3, ImagenMali3, ImagenDefault3;

    public TMP_Text World_Partida1, World_Partida2, World_Partida3;
    // Para poder borrar partidas
    private int NumberClicks_1, NumberClicks_2, NumberClicks_3;
    public GameObject VentanaBorrar;

    private int index;

    private void Start()
    {
        VentanaBorrar.SetActive(false);
        CanvasChange.SetActive(false);
        index = PlayerPrefs.GetInt("CharacterSelected");

        CharacterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)

            CharacterList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in CharacterList)
            go.SetActive(false);

        if (CharacterList[index])
        {
            CharacterList[index].SetActive(true);
        }
        PlayerPrefs.SetInt("Yaconfirmo", 0);
        Yaconfirmo = 0;
        

    }

    public void ToggleLeft()
    {
        CharacterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = CharacterList.Length - 1;
        }

        CharacterList[index].SetActive(true);
        Debug.Log(index);
    }

    public void ToggleRight()
    {
        CharacterList[index].SetActive(false);

        index++;
        if (index == CharacterList.Length)
        {
            index = 0;
        }

        CharacterList[index].SetActive(true);
    }


    //-------------------Ventana de Partidas-------------------------------
    //Pon un bol que cambie a true cuando una partida se seleccione, luego cuando presione back lo cambie a false
    //Asi decides que partida esta seleccionada, a lo mejor y una player preference
    
    void Update()
    {
        if (PlayerPrefs.GetInt("YaEscogio_1") == 1)
        {
            if (PlayerPrefs.GetInt("Partida1") == 1)
            {
                World_Partida1.text = "Mundo Burbuja";
            }
            else if (PlayerPrefs.GetInt("Partida1") == 2)
            {
                World_Partida1.text = "Terra Herbae";
            }
            else if (PlayerPrefs.GetInt("Partida1") == 3)
            {
                World_Partida1.text = "Mundo Espejo";
            }
            else if (PlayerPrefs.GetInt("Partida1") == 4)
            {
                World_Partida1.text = "Tml2ZWwgNA";
            }
            else if (PlayerPrefs.GetInt("Partida1") == 5)
            {
                World_Partida1.text = "Realidad Alterna N°5";
            }

            if (PlayerPrefs.GetInt("Index_1") == 0)
            {
                ImagenMali1.SetActive(true);
                ImagenSanjin1.SetActive(false);
                ImagenScott1.SetActive(false);
                ImagenDefault1.SetActive(false);

            }
            else if (PlayerPrefs.GetInt("Index_1") == 1)
            {
                ImagenMali1.SetActive(false);
                ImagenSanjin1.SetActive(true);
                ImagenScott1.SetActive(false);
                ImagenDefault1.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Index_1") == 2)
            {
                ImagenMali1.SetActive(false);
                ImagenSanjin1.SetActive(false);
                ImagenScott1.SetActive(true);
                ImagenDefault1.SetActive(false);
            }
        }
        else
        {
            World_Partida1.text = "__________";
            ImagenMali1.SetActive(false);
            ImagenSanjin1.SetActive(false);
            ImagenScott1.SetActive(false);
            ImagenDefault1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("YaEscogio_2") == 1)
        {
            if (PlayerPrefs.GetInt("Partida2") == 1)
            {
                World_Partida2.text = "Mundo Burbuja";
            }
            else if (PlayerPrefs.GetInt("Partida2") == 2)
            {
                World_Partida2.text = "Terra Herbae";
            }
            else if (PlayerPrefs.GetInt("Partida2") == 3)
            {
                World_Partida2.text = "Mundo Espejo";
            }
            else if (PlayerPrefs.GetInt("Partida2") == 4)
            {
                World_Partida2.text = "Tml2ZWwgNA";
            }
            else if (PlayerPrefs.GetInt("Partida2") == 5)
            {
                World_Partida2.text = "Realidad Alterna N°5";
            }

            if (PlayerPrefs.GetInt("Index_2") == 0)
            {
                ImagenMali2.SetActive(true);
                ImagenSanjin2.SetActive(false);
                ImagenScott2.SetActive(false);
                ImagenDefault2.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Index_2") == 1)
            {
                ImagenMali2.SetActive(false);
                ImagenSanjin2.SetActive(true);
                ImagenScott2.SetActive(false);
                ImagenDefault2.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Index_2") == 2)
            {
                ImagenMali2.SetActive(false);
                ImagenSanjin2.SetActive(false);
                ImagenScott2.SetActive(true);
                ImagenDefault2.SetActive(false);
            }
        }
        else
        {
            World_Partida2.text = "__________";
            ImagenMali2.SetActive(false);
            ImagenSanjin2.SetActive(false);
            ImagenScott2.SetActive(false);
            ImagenDefault2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("YaEscogio_3") == 1)
        {
            if (PlayerPrefs.GetInt("Partida3") == 1)
            {
                World_Partida3.text = "Mundo Burbuja";
            }
            else if (PlayerPrefs.GetInt("Partida3") == 2)
            {
                World_Partida3.text = "Terra Herbae";
            }
            else if (PlayerPrefs.GetInt("Partida3") == 3)
            {
                World_Partida3.text = "Mundo Espejo";
            }
            else if (PlayerPrefs.GetInt("Partida3") == 4)
            {
                World_Partida3.text = "Tml2ZWwgNA";
            }
            else if (PlayerPrefs.GetInt("Partida3") == 5)
            {
                World_Partida3.text = "Realidad Alterna N°5";
            }

            if (PlayerPrefs.GetInt("Index_3") == 0)
            {
                ImagenMali3.SetActive(true);
                ImagenSanjin3.SetActive(false);
                ImagenScott3.SetActive(false);
                ImagenDefault3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Index_3") == 1)
            {
                ImagenMali3.SetActive(false);
                ImagenSanjin3.SetActive(true);
                ImagenScott3.SetActive(false);
                ImagenDefault3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Index_3") == 2)
            {
                ImagenMali3.SetActive(false);
                ImagenSanjin3.SetActive(false);
                ImagenScott3.SetActive(true);
                ImagenDefault3.SetActive(false);
            }
        }
        else
        {
            World_Partida3.text = "__________";
            ImagenMali3.SetActive(false);
            ImagenSanjin3.SetActive(false);
            ImagenScott3.SetActive(false);
            ImagenDefault3.SetActive(true);
        }

       
    }


    public void Partida1()
    {
        NumberClicks_2 = 0;
        NumberClicks_3 = 0;
        NumberClicks_1++;
        PlayerPrefs.SetInt("Save1", 0);
        if (NumberClicks_1 >= 2)
        {
            NumberClicks_1 = 0;
        }

    }

    public void Partida2()
    {
        NumberClicks_1 = 0;
        NumberClicks_3 = 0;
        NumberClicks_2++;
        PlayerPrefs.SetInt("Save2", 0);
        if (NumberClicks_2 >= 2)
        {
            NumberClicks_2 = 0;
        }

    }

    public void Partida3()
    {
        NumberClicks_1 = 0;
        NumberClicks_2 = 0;
        NumberClicks_3++;
        PlayerPrefs.SetInt("Save3", 0);
        if (NumberClicks_3 >= 2)
        {
            NumberClicks_3 = 0;
        }
        
    }

    public void ConfirmPartida()
    {

        Yaconfirmo = 1;
        PlayerPrefs.SetInt("Yaconfirmo", Yaconfirmo);

        if (NumberClicks_1 == 1)
        {
            
            Partida1_Selected = true;
            PlayerPrefs.SetInt("Save1", 1);
            PlayerPrefs.SetInt("Save2", 0);
            PlayerPrefs.SetInt("Save3", 0);
            NumberClicks_1 = 0;
            if (PlayerPrefs.GetInt("YaEscogio_1") == 0)
            {
               CanvasPartidas.SetActive(false);
               CanvasChange.SetActive(true);
            }
            else
            {
                //PlayerPrefs.SetInt("CharacterSelected", PlayerPrefs.GetInt("Index_1"));
                SceneManager.LoadScene(7, LoadSceneMode.Single);
            }
        }

       if (NumberClicks_2 == 1)
        {
            
            Partida2_Selected = true;
            PlayerPrefs.SetInt("Save1", 0);
            PlayerPrefs.SetInt("Save2", 1);
            PlayerPrefs.SetInt("Save3", 0);
            NumberClicks_2 = 0;
            if (PlayerPrefs.GetInt("YaEscogio_2") == 0)
            {
                CanvasPartidas.SetActive(false);
                CanvasChange.SetActive(true);
            }
            else
            {
               
                SceneManager.LoadScene(7, LoadSceneMode.Single);
            }
        }
       if (NumberClicks_3 == 1)
        {
            
            Partida3_Selected = true;
            PlayerPrefs.SetInt("Save1", 0);
            PlayerPrefs.SetInt("Save2", 0);
            PlayerPrefs.SetInt("Save3", 1);
            NumberClicks_3 = 0;
            if (PlayerPrefs.GetInt("YaEscogio_3") == 0)
            {
                CanvasPartidas.SetActive(false);
                CanvasChange.SetActive(true);
            }
            else 
            {
                SceneManager.LoadScene(7, LoadSceneMode.Single);
            }
        }

       
       
        


    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void BorrarPartida()
    {

       if (NumberClicks_1 == 1)
        {
            VentanaBorrar.SetActive(true);
            
        }
        if (NumberClicks_2 == 1)
        {
            VentanaBorrar.SetActive(true);

        }
        if (NumberClicks_3 == 1)
        {
            VentanaBorrar.SetActive(true);

        }


    }

    public void Sip()
    {
        VentanaBorrar.SetActive(false);
        if (NumberClicks_1 == 1)
        {
            PlayerPrefs.SetInt("Partida1", 1);
            PlayerPrefs.SetInt("YaEscogio_1", 0);
            PlayerPrefs.SetInt("Checkpoint_Partida1", 0);
            PlayerPrefs.SetInt("MaterialA_Partida1", 0);
            PlayerPrefs.SetInt("MaterialB_Partida1", 0);
            PlayerPrefs.SetInt("Arma_Partida1", 0);
        }
        if (NumberClicks_2 == 1)
        {
            PlayerPrefs.SetInt("Partida2", 1);
            PlayerPrefs.SetInt("YaEscogio_2", 0);
            PlayerPrefs.SetInt("Checkpoint_Partida2", 0);
            PlayerPrefs.SetInt("MaterialA_Partida2", 0);
            PlayerPrefs.SetInt("MaterialB_Partida2", 0);
            PlayerPrefs.SetInt("Arma_Partida2", 0);
        }
        if (NumberClicks_3 == 1)
        {
            PlayerPrefs.SetInt("Partida3", 1);
            PlayerPrefs.SetInt("YaEscogio_3", 0);
            PlayerPrefs.SetInt("Checkpoint_Partida3", 0);
            PlayerPrefs.SetInt("MaterialA_Partida3", 0);
            PlayerPrefs.SetInt("MaterialB_Partida3", 0);
            PlayerPrefs.SetInt("Arma_Partida3", 0);
        }
        NumberClicks_1 = 0;
    }

    public void Nop()
    {
        VentanaBorrar.SetActive(false);
        NumberClicks_1 = 0;
    }
    // ------------------------------------------------


    public void BackButton_Change()
    {
        CanvasChange.SetActive(false);
        CanvasPartidas.SetActive(true);
        Partida1_Selected = false;
        Partida2_Selected = false;
        Partida3_Selected = false;
        PlayerPrefs.SetInt("Save1", 0);
        PlayerPrefs.SetInt("Save2", 0);
        PlayerPrefs.SetInt("Save3", 0);
    }


    public void ConfirmButton()
    {


        PlayerPrefs.SetInt("PartidaSelected", 0);
        PlayerPrefs.SetInt("CharacterSelected", index);

        if (Partida1_Selected == true && Partida2_Selected == false && Partida3_Selected == false)
        {
            PlayerPrefs.SetInt("PartidaSelected", PlayerPrefs.GetInt("Partida1"));
            PlayerPrefs.SetInt("Index_1", index);
            PlayerPrefs.SetInt("YaEscogio_1", 1);
        }
        else if (Partida1_Selected == false && Partida2_Selected == true && Partida3_Selected == false)
        {
            PlayerPrefs.SetInt("PartidaSelected", PlayerPrefs.GetInt("Partida2"));
            PlayerPrefs.SetInt("Index_2", index);
            PlayerPrefs.SetInt("YaEscogio_2", 1);
        }
        else if (Partida1_Selected == false && Partida2_Selected == false && Partida3_Selected == true)
        {
            PlayerPrefs.SetInt("PartidaSelected", PlayerPrefs.GetInt("Partida3"));
            PlayerPrefs.SetInt("Index_3", index);
            PlayerPrefs.SetInt("YaEscogio_3", 1);
        }
        else if (Partida1_Selected == false && Partida2_Selected == false && Partida3_Selected == false)
        {
            PlayerPrefs.GetInt("PartidaSelected", 0);
        }

        PlayerPrefs.SetInt("CharacterSelected", index);

        if (PlayerPrefs.GetInt("PartidaSelected") == 0)
        {
            PlayerPrefs.SetInt("PartidaSelected", 6);
        }

        Partida1_Selected = false;
        Partida2_Selected = false;
        Partida3_Selected = false;
        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }
}
