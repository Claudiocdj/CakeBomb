using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControllerMovement))]
public class ControllerAnimator : AnimatorFourPosController
{
    ControllerMovement Cmove;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        Cmove = GetComponent<ControllerMovement>();
    }

    // Update is called once per frame
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
