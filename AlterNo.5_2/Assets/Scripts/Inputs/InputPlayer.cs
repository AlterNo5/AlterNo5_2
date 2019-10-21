using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : InputHandler
{
    protected override Vector2 CalculateInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput = CalculateInput();
    }
}
