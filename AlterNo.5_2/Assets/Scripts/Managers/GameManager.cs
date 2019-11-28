using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    private GameCamara cam;
    private static GameManager m_instance;
    private LevelManager m_levelManager;

    public GameObject Character_1;
    public GameObject Character_2;
    public GameObject Character_3;

    // Pon el checkpoint

    public GameObject SpawnPoint_1;
    public GameObject CheckPoint;

   

    private GameObject Spawn;

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

    void Start()
    {
        

        if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
        {
            
            PlayerPrefs.SetInt("ActivoCheckpoint", PlayerPrefs.GetInt("Checkpoint_Partida1"));
            
        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
        {
            
            PlayerPrefs.SetInt("ActivoCheckpoint", PlayerPrefs.GetInt("Checkpoint_Partida2"));
           
        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
        {
           
            PlayerPrefs.SetInt("ActivoCheckpoint", PlayerPrefs.GetInt("Checkpoint_Partida3"));
            
        }


        if (PlayerPrefs.GetInt("ActivoCheckpoint") == 1)
        {
            Spawn = CheckPoint;
        }
        else
        {
            Spawn = SpawnPoint_1;
        }

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

        

        cam.SetTarget((Instantiate(player, Spawn.transform.position, player.transform.rotation) as GameObject).transform);
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








