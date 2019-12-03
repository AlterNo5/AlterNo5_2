using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamara : MonoBehaviour
{
    private Transform target;
    private float trackSpeed = 100;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
            float y = IncrementTowards(transform.position.y, target.position.y +2 , trackSpeed);
            transform.position = new Vector3(target.position.x, target.position.y + 2, transform.position.z);
        }
    }

    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
}
