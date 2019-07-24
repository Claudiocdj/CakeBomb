using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaAnimator : AnimatorFourPosController
{
    private MoveUntilColliding eMove;

    protected override void Awake()
    {
        base.Awake();

        eMove = GetComponent<MoveUntilColliding>();
    }

    private void Update()
    {
        if (eMove.isMoving)
        {
            SetAnimation( eMove.direction );
        }
    }
}
