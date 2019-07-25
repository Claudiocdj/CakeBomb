using UnityEngine;

[RequireComponent(typeof( ObjectMoveInLine ) )]
public class IaAnimator : AnimatorByDirection
{
    private ObjectMoveInLine eMove;

    protected override void Awake()
    {
        base.Awake();

        eMove = GetComponent<ObjectMoveInLine>();
    }

    private void Update()
    {
        if (eMove.isMoving)
            SetAnimation( eMove.direction );
    }
}
