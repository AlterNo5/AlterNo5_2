using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{

    public bool rotationy;
    public bool jump;
    private Vector3 startPosition;
    public float rotationSpeed;
    public float moveSpeed;
    private int direction;

    private void Start()
    {
        startPosition = transform.position;
        direction = 1;

    }
    void FixedUpdate()
    {
        if (rotationy)
        {
            transform.Rotate(new Vector3(0, 1, 0) * (rotationSpeed * Time.deltaTime));
        }
        if (jump)
        {
            if (transform.position.y >= startPosition.y+0.5f || transform.position.y <= startPosition.y - 0.5f)
            {
                direction *= -1;
            }

            transform.Translate(new Vector3(0, direction, 0) * (moveSpeed * Time.deltaTime));

        }
        
    }
}
