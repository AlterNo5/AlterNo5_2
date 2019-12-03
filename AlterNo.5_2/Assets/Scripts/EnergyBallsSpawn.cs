using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallsSpawn : MonoBehaviour
{
    public bool returnable;
    public float speed;
    private Vector3 PathB;
    private Vector3 PathA;
    private Vector3 Direction;
    public GameObject Pyectile;
    private GameObject Pyectile2;
    private bool CurrentPath=false;
    public float SpawnDelay=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;

        PathB = transform.GetChild(0).transform.position;
        PathA = this.transform.position;
        Direction = PathB;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentPath == false)
        {
            Invoke("CastEnergyBall", SpawnDelay);
            CurrentPath = true;
        }

        if (Pyectile2 != null)
        {
            if (Pyectile2.transform.position != Direction)
            {
                Pyectile2.transform.position = Vector3.MoveTowards(Pyectile2.transform.position, Direction, speed * Time.deltaTime);
            }
            else if (Pyectile2.transform.position == Direction)
            {
                if (returnable)
                {
                    if (Direction == PathB)
                    {
                        Direction = PathA;
                    }
                    else
                    {
                        Direction = PathB;
                    }
                }
                else 
                {
                    CurrentPath = false;
                    Destroy(Pyectile2);
                }
            }
        }
        
    }
    private void CastEnergyBall()
    {
        Pyectile2 = Instantiate(Pyectile, transform.position, transform.rotation);
    }
}
