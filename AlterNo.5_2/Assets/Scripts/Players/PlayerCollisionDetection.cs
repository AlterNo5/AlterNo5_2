using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCollisionDetection : MonoBehaviour
{
    public Crafteo crafteo;
    public HealthManager healthManager;
    UIManager _uiManager;

    public Transform spawnPointPersonaje_transf;
    public Transform arma_transf;

    //-------------------------------------------------

    public AudioSource Flag;
    public AudioSource PowerUp;

    public GameObject Dialog_Bubble;
    public TMP_Text Dialog_Story;

    public Transform SpawnObjDef_1;
    public Transform SpawnObjDef_2;
    public Transform Def_transf;

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

        Dialog_Bubble.SetActive(false);
        Dialog_Story.text = "     ";

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        healthManager = GameObject.Find("Player_Lives").GetComponent<HealthManager>();
        arma_transf = GameObject.Find("Arma").GetComponent<Transform>();
        Def_transf = GameObject.Find("ObjetoDef").GetComponent<Transform>();


    }

    private void Update()
    {

        if(PlayerPrefs.GetInt("Picked_Gun") == 1)
        {
            arma_transf.SetParent(spawnPointPersonaje_transf);
            arma_transf.SetPositionAndRotation(spawnPointPersonaje_transf.position, spawnPointPersonaje_transf.rotation);

        }


    }

    public void CraftObjDefence()
    {
        if (PlayerPrefs.GetInt("NumDefensas") >= 1 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Def_transf.SetParent(SpawnObjDef_1);
            Def_transf.SetPositionAndRotation(SpawnObjDef_1.position, Def_transf.rotation);

            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {

                if (PlayerPrefs.GetInt("Index_1") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }



            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {

                if (PlayerPrefs.GetInt("Index_2") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {

                if (PlayerPrefs.GetInt("Index_3") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }

            }

        }
        else if(PlayerPrefs.GetInt("NumDefensas") >= 1 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Def_transf.SetParent(SpawnObjDef_2);
            Def_transf.SetPositionAndRotation(SpawnObjDef_2.position, Def_transf.rotation);

            if(PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {

                if (PlayerPrefs.GetInt("Index_1") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }



            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {

                if (PlayerPrefs.GetInt("Index_2") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {

                if (PlayerPrefs.GetInt("Index_3") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }

            }

        }
        else if (PlayerPrefs.GetInt("NumDefensas") >= 1 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Def_transf.SetParent(SpawnObjDef_2);
            Def_transf.SetPositionAndRotation(SpawnObjDef_2.position, Def_transf.rotation);

            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {

                if (PlayerPrefs.GetInt("Index_1") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }



            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {

                if (PlayerPrefs.GetInt("Index_2") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {

                if (PlayerPrefs.GetInt("Index_3") == 0)
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 9f);
                }
                else
                {
                    Destroy(GameObject.FindWithTag("ObjetoDef"), 4f);
                }

            }

        }

        PlayerPrefs.SetInt("NumDefensas", 0);
        _uiManager.UpdateObjetoDefensa(0);
    }

    public void StoryBubble_Intro()
    {
        Dialog_Bubble.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Dialog_Story.text = "AMIGO EN CASA: Vaya la composición de este mundo es bastante singular, pero tranquilo, se resolverá si trabajamos juntos.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Dialog_Story.text = "AMIGO EN CASA: Este lugar tiene 92% de seres botánicos, debes ir con cautela, no sabemos si hay plantas venenosas.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Dialog_Story.text = "AMIGO EN CASA: El radar detecta muchos elementos metálicos, Pisa con cuidado no te vayas a cortar.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Dialog_Story.text = "AMIGO EN CASA: El radar no detecta nada, háblame... ¿qué ves? ¿Qué es esto? No hay nada... es como si estuviera rota. Si fueron esas máquinas… debo hacer algo para impedir que esto le pase a otra dimensión, a la nuestra o a nuest@ amig@";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Dialog_Story.text = "AMIGO EN CASA: Mmmm… este lugar no me da buena espina…Detecto peligro en casi todas las zonas. Pero ¡al fin encontramos la dimensión que hemos estado buscando!";
        }
    }

    public void StoryBubble_Checkpoint()
    {
        Dialog_Bubble.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Dialog_Story.text = "AMIGO EN CASA:  El rastreador indica que algo grande se acerca, presiento que no va a ser nada bueno, usa el arma.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Dialog_Story.text = "AMIGO EN CASA: Esta planta tiene mecanismos de defensa más potentes que las otras, cuidado.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Dialog_Story.text = "AMIGO EN CASA: El radar dice que hay energía magnética más adelante, vamos con todo, no podemos perder.";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Dialog_Story.text = "____";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Dialog_Story.text = "AMIGO EN CASA:... ";
        }
    }

    public void NoMoreStory()
    {
        Dialog_Bubble.SetActive(false);
    }

    public void LoadDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    //  *****************  Método OnTriggerEnter  ***********************
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Restaurador")
        {
            healthManager.RestaurarVida();
            healthManager.UpdateLives();


            if (!PowerUp.isPlaying)
            {
                PowerUp.Play();
            }
            Destroy(other.gameObject);

        }

        if (other.tag == "MatB")
        {
            crafteo.AddMatB();
            crafteo.Fabricar_Arma();


            if (!PowerUp.isPlaying)
            {
                PowerUp.Play();
            }
            Destroy(other.gameObject);
        }

        if(other.tag == "MatA")
        {
            crafteo.AddMatA();
            crafteo.Fabricar_Arma();


            if (!PowerUp.isPlaying)
            {
                PowerUp.Play();
            }

            Destroy(other.gameObject);

        }

        if(other.tag =="Arma")
        {
            crafteo.Arma();
            PlayerPrefs.SetInt("Picked_Gun", 1);
            PlayerPrefs.SetInt("Arma_Guardada", 1);

            if (!PowerUp.isPlaying)
            {
                PowerUp.Play();
            }
        }

        if(other.tag == "Pitfall")
        {
            Invoke("LoadDeath", 0.3f);
        }

        if (other.tag == "Story_Intro")
        {
            Invoke("StoryBubble_Intro", 0f);
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                Invoke("NoMoreStory", 8f);
            }
            else
            {
                Invoke("NoMoreStory", 15f);
            }
            
        }


        if(other.tag == "Flag")
        {

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

            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {


                PlayerPrefs.SetInt("MaterialA_Partida1", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida1", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida1", PlayerPrefs.GetInt("Arma_Guardada"));
                PlayerPrefs.SetInt("Checkpoint_Partida1", PlayerPrefs.GetInt("ActivoCheckpoint"));

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {


                PlayerPrefs.SetInt("MaterialA_Partida2", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida2", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida2", PlayerPrefs.GetInt("Arma_Guardada"));
                PlayerPrefs.SetInt("Checkpoint_Partida2", PlayerPrefs.GetInt("ActivoCheckpoint"));

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {


                PlayerPrefs.SetInt("MaterialA_Partida3", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida3", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida3", PlayerPrefs.GetInt("Arma_Guardada"));
                PlayerPrefs.SetInt("Checkpoint_Partida3", PlayerPrefs.GetInt("ActivoCheckpoint"));

            }

            Flag.Play();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "Checkpoint")
        {



            PlayerPrefs.SetInt("ActivoCheckpoint", 1);
            //Debug.Log(PlayerPrefs.GetInt("ActivoCheckpoint"));

            if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
            {


                PlayerPrefs.SetInt("MaterialA_Partida1", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida1", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida1", PlayerPrefs.GetInt("Arma_Guardada"));
                PlayerPrefs.SetInt("Checkpoint_Partida1", PlayerPrefs.GetInt("ActivoCheckpoint"));

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
            {


                PlayerPrefs.SetInt("MaterialA_Partida2", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida2", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida2", PlayerPrefs.GetInt("Arma_Guardada"));
                PlayerPrefs.SetInt("Checkpoint_Partida2", PlayerPrefs.GetInt("ActivoCheckpoint"));

            }
            else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
            {


                PlayerPrefs.SetInt("MaterialA_Partida3", PlayerPrefs.GetInt("MaterialA_Guardado"));
                PlayerPrefs.SetInt("MaterialB_Partida3", PlayerPrefs.GetInt("MaterialB_Guardado"));
                PlayerPrefs.SetInt("Arma_Partida3", PlayerPrefs.GetInt("Arma_Guardada"));
                PlayerPrefs.SetInt("Checkpoint_Partida3", PlayerPrefs.GetInt("ActivoCheckpoint"));

            }
            //Debug.Log(PlayerPrefs.GetInt("MaterialA_Partida1"));
            Invoke("StoryBubble_Checkpoint", 0f);
            Invoke("NoMoreStory",8f);


        }
    }
}
