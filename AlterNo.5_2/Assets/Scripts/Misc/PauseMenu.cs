using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool PausedGame = false;
    public GameObject PauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
            
    }

    void Resume()
    {
        if (PausedGame == true) 
        { 
        PauseCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        PausedGame = false;
        }
        else
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            PausedGame = true;
        }
    }

    
    public void ClickContinuar()
    {
        Resume();
    }

    public void ClickAjustes()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void ClickSalir()
    {
        PlayerPrefs.SetInt("Partida_1", 1);
        Resume();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
