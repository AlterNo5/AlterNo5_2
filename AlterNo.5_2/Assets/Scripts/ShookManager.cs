using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShookManager : MonoBehaviour
{
    GameObject Objective;
    private bool rayDistance;
    Transform original;

    // Start is called before the first frame update
    void Start()
    {
        original = this.gameObject.transform;
    }

    void inRange(bool w)
    {
        rayDistance = w;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
          
            RaycastHit hit;
            if(Physics.Raycast(transform.position,Vector3.forward,out hit)){
                Debug.Log(hit.distance);
                Objective = hit.transform.gameObject;
                transform.LookAt(hit.transform.gameObject.transform.position);
                if (hit.distance <= 2f && hit.transform.CompareTag("Enemy"))
                {
                    
                    Debug.DrawLine(transform.position, hit.point, Color.green);
                    hit.transform.gameObject.GetComponent<EnemyW5Movement>().shoocked = true;
                }
                else {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
            
        }


    }
}
