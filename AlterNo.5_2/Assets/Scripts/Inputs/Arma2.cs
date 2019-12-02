using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma2 : MonoBehaviour
{

    public bool isEquiped;
    public bool smokeUsed = false;
    public Crafteo ammo;
    public GameObject smoke;
    public ParticleSystem smokeOld;
    public Transform origin;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GameObject.FindObjectOfType<Crafteo>().gameObject.GetComponent<Crafteo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEquiped && Input.GetButtonDown("Fire1") && !smokeUsed && ammo.armaCreada > 0)
        {
            smokeOld = Instantiate(smoke, origin.transform).GetComponentInChildren<ParticleSystem>();
            smokeOld.transform.localScale = new Vector3(.5f, .5f, .1f);
            ammo.armaCreada -= 1;
            ammo.AmmoUsed();
            smokeUsed = true;
        }
        if (smokeOld != null && !smokeOld.isEmitting)
        {
            smokeOld.transform.parent.gameObject.transform.parent = null;            
            
        }
        if (smokeOld != null && !smokeOld.IsAlive())
        {
            Destroy(smokeOld.gameObject.transform.parent.gameObject);
            smokeUsed = false;
        }
    }
}
