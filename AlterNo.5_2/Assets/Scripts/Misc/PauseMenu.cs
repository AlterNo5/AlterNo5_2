using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool PausedGame = false;
    public GameObject PauseCanvas;
    public GameObject AjusteCanvas;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false);
        AjusteCanvas.SetActive(false);
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
        AjusteCanvas.SetActive(false);
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
        AjusteCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
    }

    public void BackToGame()
    {
        AjusteCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
    }

    public void ClickSalir()
    {
        if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
        {
            PlayerPrefs.SetInt("Partida1", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Checkpoint_Partida1", PlayerPrefs.GetInt("ActivoCheckpoint"));
        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
        {
            PlayerPrefs.SetInt("Partida2", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Checkpoint_Partida2", PlayerPrefs.GetInt("ActivoCheckpoint"));
        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
        {
            PlayerPrefs.SetInt("Partida3", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Checkpoint_Partida3", PlayerPrefs.GetInt("ActivoCheckpoint"));
        }

        
        Resume();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
