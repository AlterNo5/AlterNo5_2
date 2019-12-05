using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustSkip : MonoBehaviour
{
    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Invoke("LoadScene", 0.5f);
            Debug.Log("CONTINUE");
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(9, LoadSceneMode.Single);
    }
}
