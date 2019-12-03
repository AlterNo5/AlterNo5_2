using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma2 : MonoBehaviour
{

    public bool isEquiped;
    public bool smokeUsed = false;
    public Crafteo ammo;
    public GameObject smokeAttack;
    public ParticleSystem smokeAttackOld;
    public GameObject smokeGrow;
    public ParticleSystem smokeGrowOld;
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
            smokeAttackOld = Instantiate(smokeAttack, origin.transform).GetComponentInChildren<ParticleSystem>();
            smokeAttackOld.transform.localScale = new Vector3(.5f, .5f, .1f);
            ammo.armaCreada -= 1;
            ammo.AmmoUsed();
            smokeUsed = true;
        }
        if (smokeAttackOld != null && !smokeAttackOld.isEmitting)
        {
            smokeAttackOld.transform.parent.gameObject.transform.parent = null;            
            
        }
        if (smokeAttackOld != null && !smokeAttackOld.IsAlive())
        {
            Destroy(smokeAttackOld.gameObject.transform.parent.gameObject);
            smokeUsed = false;
        }

        if (isEquiped && Input.GetButtonDown("Fire2") && !smokeUsed && ammo.objeto_creado > 0)
        {
            smokeGrowOld = Instantiate(smokeGrow, origin.transform).GetComponentInChildren<ParticleSystem>();
            smokeGrowOld.transform.localScale = new Vector3(.5f, .5f, .1f);
            ammo.objeto_creado -= 1;
            ammo.AmmoUsed();
            smokeUsed = true;
        }
        if (smokeGrowOld != null && !smokeGrowOld.isEmitting)
        {
            smokeGrowOld.transform.parent.gameObject.transform.parent = null;

        }
        if (smokeGrowOld != null && !smokeGrowOld.IsAlive())
        {
            Destroy(smokeGrowOld.gameObject.transform.parent.gameObject);
            smokeUsed = false;
        }
    }
}
