using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public static bool bossEncounter = false;
    public static bool bossIsDeath = false;
    public Transform portalSpawn;
    public BoxCollider barrera;
    public GameObject portal;
    public GameObject portalActivo;

    // Start is called before the first frame update
    void Start()
    {
        barrera = GetComponent<BoxCollider>();
        if (barrera != null)
        {
            barrera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bossEncounter && barrera != null)
        {
            barrera.enabled = true;
            if(portalActivo != null)
            {
                Destroy(portalActivo.gameObject);
            }
        }

        if (bossIsDeath && barrera != null)
        {
            barrera.enabled = false;
        }
        if (bossIsDeath && portal != null && portalActivo == null)
        {
            portalActivo = Instantiate(portal, portalSpawn);
        }

    }
}
