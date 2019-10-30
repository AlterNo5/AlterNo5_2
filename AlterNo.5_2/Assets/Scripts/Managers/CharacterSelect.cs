using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private GameObject[] CharacterList;
    public GameObject CanvasChange;

    // Will later update number with savestate, right now this is my approach
    private int SceneNumber = 0;
    public GameObject CanvasPartidas;
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
    public void Partida1()
    {
        NumberClicks_2 = 0;
        NumberClicks_3 = 0;
        NumberClicks_1++;
        
        if (NumberClicks_1 >= 2)
        {
            CanvasPartidas.SetActive(false);
            CanvasChange.SetActive(true);
            PlayerPrefs.SetInt("Partida_1", 1);
            NumberClicks_1 = 0;
        }
     

    }

    public void Partida2()
    {
        NumberClicks_1 = 0;
        NumberClicks_3 = 0;
        NumberClicks_2++;
        if (NumberClicks_2 >= 2)
        {
            CanvasPartidas.SetActive(false);
            CanvasChange.SetActive(true);
            PlayerPrefs.SetInt("Partida_2", 1);
            NumberClicks_2 = 0;
        }
    }

    public void Partida3()
    {
        NumberClicks_1 = 0;
        NumberClicks_2 = 0;
        NumberClicks_3++;
        if (NumberClicks_3 >= 2)
        {
            CanvasPartidas.SetActive(false);
            CanvasChange.SetActive(true);
            PlayerPrefs.SetInt("Partida_3", 1);
            NumberClicks_3 = 0;
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
        NumberClicks_1 = 0;
        PlayerPrefs.SetInt("Partida_1", 0);
    }

    public void Nop()
    {
        VentanaBorrar.SetActive(false);
        NumberClicks_1 = 0;
    }
    // ------------------------------------------------

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Partida_1"), LoadSceneMode.Single);
    }
}
