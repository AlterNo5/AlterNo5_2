using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject AjustesCanvas;

    void Start()
    {
        AjustesCanvas.SetActive(false);
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single); // tambien se puede poner el nombre de la escena, aditivo se cargan las dos y single solo una
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

    public void ClickAjustes()
    {
        AjustesCanvas.SetActive(true);
    }

    public void ExitToMenu()
    {
        AjustesCanvas.SetActive(false);
    }

    public void ClickPartidas()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void ClickPausa()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void ClickSalir()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
