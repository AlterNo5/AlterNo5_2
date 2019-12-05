using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Project.Player
{

    public class Boss5Health : MonoBehaviour
    {

        public float healthPoints;
        public Boss5Attacks bossAttacks;
        public Animator self_Anim;

        public GameObject ScottVineta;
        public GameObject MaliVineta;
        public GameObject SanjinVineta;
        public GameObject CanvasGeneral;

        public GameObject Portal;
        public GameObject SpawnPortal;

        // Start is called before the first frame update
        void Start()
        {
            self_Anim = GetComponent<Animator>();
            ScottVineta.SetActive(false);
            MaliVineta.SetActive(false);
            SanjinVineta.SetActive(false);
            CanvasGeneral.SetActive(false);
        }


        public void ViñetaIntermedio()
        {
            Time.timeScale = 0f;
            CanvasGeneral.SetActive(true);
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

        public void ApagarViñeta()
        {
            CanvasGeneral.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Arma")
            {
                healthPoints -= 1;
                self_Anim.SetTrigger("Damage");
                if (healthPoints <= 0)
                {
                    Instantiate(Portal, SpawnPortal.transform.position, SpawnPortal.transform.rotation);
                    Destroy(this.gameObject, 5f);
                }
                else if(healthPoints == 5)
                {
                    Invoke("ViñetaIntermedio", 1f);
                    Invoke("ApagarViñeta", 5f);
                }
                else
                {
                bossAttacks.atk3Start = true;

                }

            }
        }
    }
}
