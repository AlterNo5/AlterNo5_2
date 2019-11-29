using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionDetection : MonoBehaviour
{
    public Crafteo crafteo;
    HealthManager healthManager;
    UIManager _uiManager;

    public Transform spawnPointPersonaje_transf;
    public Transform arma_transf;
    public Transform player_transform;
    private bool PickGun = false;



    private void Start()
    {


        PlayerPrefs.SetInt("Arma_Guardada", 0);
        if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Arma_Partida1") == 1)
        {

            PlayerPrefs.SetInt("Picked_Gun", 1);


        }
        else if (PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Arma_Partida2") == 1)
        {

            PlayerPrefs.SetInt("Picked_Gun", 1);


        }
        else if (PlayerPrefs.GetInt("Save3") == 1 && PlayerPrefs.GetInt("Arma_Partida3") == 1)
        {

            PlayerPrefs.SetInt("Picked_Gun", 1);


        }
        else
        {
            PlayerPrefs.SetInt("Picked_Gun", 0);
        }




        player_transform= GetComponent<Transform>();
        arma_transf = GameObject.Find("Arma").GetComponent<Transform>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        crafteo = GetComponent<Crafteo>();


    }

    private void Update()
    {

        if(PlayerPrefs.GetInt("Picked_Gun") == 1)
        {
            arma_transf.SetParent(spawnPointPersonaje_transf);
            arma_transf.SetPositionAndRotation(spawnPointPersonaje_transf.position, spawnPointPersonaje_transf.rotation);
        }


    }

    //  *****************  Método OnTriggerEnter  ***********************
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Restaurador")
        {
            healthManager.RestaurarVida();
            healthManager.UpdateLives();
            Destroy(other.gameObject);

        }

        if (other.tag == "MatB")
        {
            crafteo.AddMatB();
            crafteo.Fabricar_Arma();
            Destroy(other.gameObject);
        }

        if(other.tag == "MatA")
        {
            crafteo.AddMatA();
            crafteo.Fabricar_Arma();

            Destroy(other.gameObject);

        }

        if(other.tag =="Arma")
        {
            crafteo.Arma();
            PlayerPrefs.SetInt("Picked_Gun", 1);
            PlayerPrefs.SetInt("Arma_Guardada", 1);




        }

        if(other.tag == "Flag")
        {

           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("ActivoCheckpoint", 0);
            PlayerPrefs.SetInt("MaterialA_Partida1", 0);
            PlayerPrefs.SetInt("MaterialB_Partida1", 0);
            PlayerPrefs.SetInt("Arma_Partida1", 0);

            PlayerPrefs.SetInt("MaterialA_Partida2", 0);
            PlayerPrefs.SetInt("MaterialB_Partida2", 0);
            PlayerPrefs.SetInt("Arma_Partida2", 0);

            PlayerPrefs.SetInt("MaterialA_Partida3", 0);
            PlayerPrefs.SetInt("MaterialB_Partida3", 0);
            PlayerPrefs.SetInt("Arma_Partida3", 0);

            PlayerPrefs.SetInt("Arma_Guardada", 0);
            PlayerPrefs.SetInt("Picked_Gun", 0);
        }

        if(other.tag == "Checkpoint")
        {

            PlayerPrefs.SetInt("ActivoCheckpoint", 1);
            //Debug.Log(PlayerPrefs.GetInt("ActivoCheckpoint"));

            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {


                PlayerPrefs.SetInt("MaterialA_Partida1", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida1", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida1", PlayerPrefs.GetInt("Arma_Guardada"));


            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {


                PlayerPrefs.SetInt("MaterialA_Partida2", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida2", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida2", PlayerPrefs.GetInt("Arma_Guardada"));


            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {


                PlayerPrefs.SetInt("MaterialA_Partida3", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida3", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida3", PlayerPrefs.GetInt("Arma_Guardada"));


            }
            //Debug.Log(PlayerPrefs.GetInt("MaterialA_Partida1"));

        }
    }
}
