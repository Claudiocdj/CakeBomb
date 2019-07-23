using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : Movement
{
    public bool InputRight { get; private set; }
    public bool InputLeft { get; private set; }
    public bool InputDown { get; private set; }
    public bool InputUp { get; private set; }

    private void Update()
    {
        InputRight = Input.GetKey( KeyCode.RightArrow );

        InputLeft = Input.GetKey( KeyCode.LeftArrow );

        InputUp = Input.GetKey( KeyCode.UpArrow );

        InputDown = Input.GetKey( KeyCode.DownArrow );

        if (InputLeft)
            Move( Vector2.left );

        if (InputRight)
            Move( Vector2.right );

        if (InputUp)
            Move( Vector2.up );

        if (InputDown)
            Move( Vector2.down );

        if(!InputLeft && !InputRight && !InputUp && !InputDown)
            Move( Vector2.zero );
    }
}
