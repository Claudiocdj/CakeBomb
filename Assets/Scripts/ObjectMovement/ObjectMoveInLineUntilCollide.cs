using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveInLineUntilCollide : GridMovement
{
    public Vector3 direction;

    private bool stopMovement = false;

    protected override void Start()
    {
        base.Start();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    protected virtual void Update()
    {
        if (!isMoving && !stopMovement)
        {
            if (direction == Vector3.zero || !CanMove( transform.position + direction ))
                stopMovement = true;

            else if (direction != Vector3.zero)
                Move( direction );
        }
    }
}
