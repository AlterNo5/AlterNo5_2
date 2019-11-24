using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGrowth : MonoBehaviour
{
    public BoxCollider platCollider;
    public float platFinalHeight;
    private float platFinalPosition;
    public bool canGrow = false;

    void Start()
    {
        platFinalPosition = platFinalHeight / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Player":
                canGrow = true;
                break;
        }
    }

    void Update()
    {
        if (canGrow)
        {
            platCollider.size = new Vector3(1, platFinalHeight, 1);
            platCollider.center = new Vector3(0, platFinalPosition, 0);
            canGrow = false;
        }
    }
}
