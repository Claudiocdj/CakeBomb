using UnityEngine;

public class InputControllerMovement : Movement
{
    [SerializeField]
    private KeyCode leftArrow = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode rightArrow = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode upArrow = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode downArrow = KeyCode.DownArrow;

    public bool InputRight { get; private set; }
    public bool InputLeft { get; private set; }
    public bool InputDown { get; private set; }
    public bool InputUp { get; private set; }

    private void Update()
    {
        InputRight = Input.GetKey( rightArrow );

        InputLeft = Input.GetKey( leftArrow );

        InputUp = Input.GetKey( upArrow );

        InputDown = Input.GetKey( downArrow );

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
