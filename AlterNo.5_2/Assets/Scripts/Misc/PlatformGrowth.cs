using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGrowth : MonoBehaviour
{
    public BoxCollider platCollider;
    public GameObject hierba;
    public float hierbaScale;
    public float platFinalHeight;
    private float platFinalPosition;
    public Vector3 originalSizeColl;
    public bool canGrow = false;
    public bool isReseting = false;

    void Start()
    {
        platFinalPosition = platFinalHeight / 2;
        originalSizeColl = platCollider.size;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "GasGrow":
                canGrow = true;
                platCollider.isTrigger = false;
                break;
            case "Bullet":
                isReseting = true;
                platCollider.isTrigger = true;
                break;
        }
    }

    void Update()
    {
        if (canGrow)
        {
            if (platCollider.size.z < platFinalHeight)
            {
                platCollider.center = new Vector3(0, 0, 0);
                platCollider.size = new Vector3(platCollider.size.x, platCollider.size.y, platCollider.size.z + 11f * 11 * Time.deltaTime);
            }
            if (hierba.transform.localScale.z < hierbaScale)
            {
                hierba.transform.localScale = new Vector3(hierba.transform.localScale.x, hierba.transform.localScale.y, hierba.transform.localScale.z + 0.25f * 3 * Time.deltaTime);
            }
            if (hierba.transform.localScale.z >= hierbaScale && platCollider.size.z >= platFinalHeight)
            {
                canGrow = false;
                platCollider.center = new Vector3(0, 0, 0);
            }
        }

        if (isReseting)
        {
            if (platCollider.size.z > originalSizeColl.z)
            {
                platCollider.size = new Vector3(platCollider.size.x, platCollider.size.y, platCollider.size.z - 10f * 10 * Time.deltaTime);
            }
            if (hierba.transform.localScale.z > 0)
            {
                hierba.transform.localScale = new Vector3(hierba.transform.localScale.x, hierba.transform.localScale.y, hierba.transform.localScale.z - 0.25f * 2 * Time.deltaTime);
            }
            if (hierba.transform.localScale.z <= 0 && platCollider.size.z <= originalSizeColl.z)
            {
                isReseting = false;
                platCollider.center = new Vector3(0, 0, 0);
            }
        }
    }
}
