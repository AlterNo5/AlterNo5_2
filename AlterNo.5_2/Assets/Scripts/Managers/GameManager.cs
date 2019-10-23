using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private GameCamara cam;
    private static GameManager m_instance;

    public GameObject Character_1;
    public GameObject Character_2;
    public GameObject Character_3;
    
    
    
    //Propiedad
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                GameObject go = new GameObject("GameManager"); // crea un objeto vacio y le pone nombre
                m_instance = go.AddComponent<GameManager>(); // es para agregar un componente en este caso es el gameManager
            }

            return m_instance;
        }
    }

    private LevelManager m_levelManager;


    void Start()
    {

        // player.transform.Rotate(0, 90, 0);
        cam = GetComponent<GameCamara>();
        SpawnPlayer();

    }

    private void SpawnPlayer()
    {

        if (PlayerPrefs.GetInt("CharacterSelected") == 0)
        {
            player = Character_1;
        }
        else if (PlayerPrefs.GetInt("CharacterSelected") == 1)
        {
            player = Character_2;
        }
        else if (PlayerPrefs.GetInt("CharacterSelected") == 2)
        {
            player = Character_3;
        }

        cam.SetTarget((Instantiate(player, Vector3.zero, player.transform.rotation) as GameObject).transform);
    }

    // obtener el limite superior
    public Transform GetLimiteSuperior
    {
        get { return m_levelManager.m_limiteSuperior_obj; }
    }

    // obtener el limite inferior
    public Transform GetLimiteInferior
    {
        get { return m_levelManager.m_limiteInferior_obj; }
    }

    // para iniciar el nivel
    public void InitLevel(LevelManager levelManager)
    {
        m_levelManager = levelManager;
    }
}








