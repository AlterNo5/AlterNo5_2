using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationEvents : MonoBehaviour
{
   public GameObject Seed;
    public GameObject Projectil;
   public Transform origin;
    private float force;

    public void ShootSeed()
    {

        force = UnityEngine.Random.Range(15f, 30f);
        Projectil = Instantiate(Seed, origin.position, origin.rotation);
        Projectil.GetComponent<Rigidbody>().AddForce((transform.forward+(transform.up*0.45f   )) * force, ForceMode.Impulse);
    }
}
