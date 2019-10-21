using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{
    public Vector2 GetInput
    {
        get; protected set;
    }

    protected abstract Vector2 CalculateInput();
}

