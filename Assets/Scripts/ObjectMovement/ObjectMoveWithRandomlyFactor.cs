using UnityEngine;

public class ObjectMoveWithRandomlyFactor : ObjectMoveInLine
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
        int n = Random.Range( 0, 100 );

        if (n < probabilityOfChange)
            return true;
        return false;
    }


}
