using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : InputHandler
{
    public Vector2 m_fakeInput = Vector2.zero;

    protected override Vector2 CalculateInput()
    {

        //  return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        return m_fakeInput;
    }



    // Update is called once per frame
    void Update()
    {
        GetInput = CalculateInput();
    }
}
