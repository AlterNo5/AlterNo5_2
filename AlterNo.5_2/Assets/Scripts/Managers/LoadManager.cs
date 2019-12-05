using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadManager : MonoBehaviour
{
    public TMP_Text Count;
    public static bool isLoading = false;
    public GameObject LoadCanvas;
    public GameObject PressAny;


    private void Awake()
    {
        PressAny.SetActive(false);
    }

    IEnumerator Start()
    {

        isLoading = true;
        float FakeProgress = 99f;
        yield return new WaitForSeconds(0.5f);
        float prog = 0;

        // -----------------------------------------------------------

        if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
        {
            PlayerPrefs.SetInt("Escena_QueViene", PlayerPrefs.GetInt("Partida1"));

        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
        {
            PlayerPrefs.SetInt("Escena_QueViene", PlayerPrefs.GetInt("Partida2"));

        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
        {
            PlayerPrefs.SetInt("Escena_QueViene", PlayerPrefs.GetInt("Partida3"));

        }
        else
        {
            PlayerPrefs.SetInt("Escena_QueViene", 1);
        }
        
        //-----------------------------------------------------------------


        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("Escena_QueViene"), LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;



        while (prog < FakeProgress)
        {
            prog++;
            Count.text = $"LOADING... {(asyncOperation.progress + prog).ToString("000")}%";
            yield return new WaitForEndOfFrame();
        }

        while (!asyncOperation.isDone)
        {
            Count.text = $"LOADING... {(asyncOperation.progress + prog).ToString("000")}%";
            PressAny.SetActive(true);

            if (asyncOperation.progress >= 0.9f && Input.GetKeyUp(KeyCode.Space))
            {
                asyncOperation.allowSceneActivation = true;
                
            }

            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        
        Count.text = $"LOADING... 100%";
        LoadCanvas.SetActive(false);
        isLoading = false;




    }

   





}
