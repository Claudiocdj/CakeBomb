using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUntilColliding : EnemyMove
{
    protected Vector3 direction;

    private List<Vector3> positions = new List<Vector3>()
    { Vector3.up, Vector3.left, Vector3.right, Vector3.down };

    protected override void Start()
    {
        base.Start();

        direction = FindNewDirection();
    }

    protected virtual void Update()
    {
        if (!isMoving)
        {
            if(direction == Vector3.zero || !CanMove(transform.position + direction ))
                    direction = FindNewDirection();

            if(direction != Vector3.zero)
                Move( direction );
        }
    }

    protected Vector3 FindNewDirection()
    {
        int n;

        List<Vector3> localPos = new List<Vector3>( positions );

        while (localPos.Count > 0)
        {
            n = Random.Range( 0, localPos.Count );

            if (CanMove( transform.position + localPos[n] ))
                return localPos[n];

            else
                localPos.RemoveAt( n );
        }

        return Vector3.zero;
    }
}
