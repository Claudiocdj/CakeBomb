using UnityEngine;

[RequireComponent(typeof(InputControllerMovement))]
public class ControllerAnimator : AnimatorByDirection
{
    InputControllerMovement Cmove;

    protected override void Awake()
    {
        base.Awake();

        Cmove = GetComponent<InputControllerMovement>();
    }
    
    void Update()
    {
        if (Cmove.InputLeft)
            SetAnimation( Vector2.left );

        if (Cmove.InputRight)
            SetAnimation( Vector2.right );

        if (Cmove.InputUp)
            SetAnimation( Vector2.up );

        if (Cmove.InputDown)
            SetAnimation( Vector2.down );
    }
}
