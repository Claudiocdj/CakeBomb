using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionRandomly : MoveUntilColliding
{
    [SerializeField]
    [Range( 0, 100 )]
    private int probabilityOfChange;

    protected override void Update()
    {
        if (!isMoving)
        {
            if (ChangeDirection())
                direction = FindNewDirection();
    
            if (direction != Vector3.zero)
                Move( direction );
        }

        base.Update();    
    }

    private bool ChangeDirection()
    {
        int n = Random.Range( 0, 101 );

        if (n < probabilityOfChange)
            return true;
        return false;
    }


}
