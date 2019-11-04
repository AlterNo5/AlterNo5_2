using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour
{

    public LayerMask collisionMask;
    public BoxCollider collider;
    private Vector3 s;
    private Vector3 c;

    private Vector3 originalSize;
    private Vector3 originalCentre;
    private float colliderScale;
    private float skin = .005f;

    [HideInInspector]
    public bool grounded;
    [HideInInspector]
    public bool movementStopped;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
        colliderScale = transform.localScale.x;
        originalSize = collider.size;
        originalCentre = collider.center;
        SetCollider(originalSize, originalCentre);

    }

    public void Move(Vector2 moveAmount)
    {
        float deLtaY = moveAmount.y;
        float deLtaX = moveAmount.x;
        Vector2 p = transform.position;

        // check collisions above and below
        grounded = false;
        for (int i = 0; i < 3; i++)
        {
            float dir = Mathf.Sign(deLtaY);
            float x = (p.x + c.x - s.x / 2) + s.x / 2 * i;       // Left, centre and then rightmost point of collider
            float y = p.y + c.y + s.y / 2 * dir;  // bottom of collider

            ray = new Ray(new Vector2(x, y), new Vector2(0, dir));

                Debug.DrawRay(ray.origin, ray.direction);

            if (Physics.Raycast(ray, out hit, Mathf.Abs(deLtaY) + skin, collisionMask))
            {
                // get distance between player and ground
                float dst = Vector3.Distance(ray.origin, hit.point);

                // stop player´s downwards movement after coming within skin width 
                if (dst > skin)
                {
                    deLtaY = dst * dir - skin * dir;
                }
                else
                {
                    deLtaY = 0;
                }
                grounded = true;
                break;
            }
        }

        // left and right collisions
        movementStopped = false;
        for (int i = 0; i < 3; i++)
        {
            float dir = Mathf.Sign(deLtaX);
            float x = p.x + c.x + s.x / 2 * dir;
            float y = p.y + c.y - s.y / 2 + s.y / 2 * i;

            ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));

            //  Debug.DrawRay(ray.origin, ray.direction);

            if (Physics.Raycast(ray, out hit, Mathf.Abs(deLtaX) + skin, collisionMask))
            {
                float dst = Vector3.Distance(ray.origin, hit.point);

                if (dst > skin)
                {
                    deLtaX = dst * dir - skin * dir;
                }
                else
                {
                    deLtaX = 0;
                }
                movementStopped = true;
                break;
            }
        }

        if (grounded && !movementStopped)
        {
            Vector3 playerDir = new Vector3(deLtaX, deLtaY);
            Vector3 o = new Vector3(p.x + c.x + s.x / 2 * Mathf.Sign(deLtaX), p.y + c.y + s.y / 2 * Mathf.Sign(deLtaY));
            ray = new Ray(o, playerDir.normalized);

            if (Physics.Raycast(ray, Mathf.Sqrt(deLtaX * deLtaX + deLtaY * deLtaY), collisionMask))
            {
                grounded = true;
                deLtaY = 0;

            }

        }

        Vector2 finalTransform = new Vector2(deLtaX, deLtaY);
        transform.Translate(finalTransform, Space.World);
    }

    public void SetCollider(Vector3 size, Vector3 centre)
    {
        collider.size = size;
        collider.center = centre;

        s = size * colliderScale;
        c = centre * colliderScale;
    }
}
