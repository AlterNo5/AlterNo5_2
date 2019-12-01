using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationEventsJefe2 : MonoBehaviour
{
   public GameObject Seed;
   public Transform origin;
    private float force;

    public void ShootSeed()
    {

        force = UnityEngine.Random.Range(15f, 30f);
        Seed=Instantiate(Seed, origin.position, origin.rotation);
        Seed.GetComponent<Rigidbody>().AddForce((transform.forward+(transform.up*0.45f   )) * force, ForceMode.Impulse);
    }
}
