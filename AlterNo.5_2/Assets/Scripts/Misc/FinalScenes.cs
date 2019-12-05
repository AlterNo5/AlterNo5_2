using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScenes : MonoBehaviour
{

    public GameObject ScottVineta;
    public GameObject MaliVineta;
    public GameObject SanjinVineta;

    void Start()
    {
        ScottVineta.SetActive(false);
        MaliVineta.SetActive(false);
        SanjinVineta.SetActive(false);

        if (PlayerPrefs.GetInt("Save1") == 1 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 0)
        {

            

            if (PlayerPrefs.GetInt("Index_1") == 0)
            {
                MaliVineta.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Index_1") == 1)
            {
                SanjinVineta.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Index_1") == 2)
            {
                ScottVineta.SetActive(true);
            }


        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 1 && PlayerPrefs.GetInt("Save3") == 0)
        {

            
            if (PlayerPrefs.GetInt("Index_2") == 0)
            {
                MaliVineta.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Index_2") == 1)
            {
                SanjinVineta.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Index_2") == 2)
            {
                ScottVineta.SetActive(true);
            }

        }
        else if (PlayerPrefs.GetInt("Save1") == 0 && PlayerPrefs.GetInt("Save2") == 0 && PlayerPrefs.GetInt("Save3") == 1)
        {

            
            if (PlayerPrefs.GetInt("Index_3") == 0)
            {
                MaliVineta.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Index_3") == 1)
            {
                SanjinVineta.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Index_3") == 2)
            {
                ScottVineta.SetActive(true);
            }

        }

        


    }

    

}
