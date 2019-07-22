using System.Collections;
using UnityEngine;

public class MoveUntilColliding : Movement
{
    [SerializeField]
    private Vector2 direction = Vector2.zero;

    private Vector2[] dirOp = {Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    public MovementSensor mvSensor;

    public bool right;
    public bool left;
    public bool up;
    public bool down;

    private void Start()
    {
        SetDirection();
    }

    private void Update()
    {
        right = mvSensor.GetSensor( Vector2.right );
        left = mvSensor.GetSensor( Vector2.left );
        up = mvSensor.GetSensor( Vector2.up );
        down = mvSensor.GetSensor( Vector2.down );

        if (IsArrested())
            direction = Vector2.zero;

        else if (mvSensor.GetSensor(direction))
            SetDirection();

        Move( direction );
    }

    private bool IsArrested()
    {
        foreach(var dir in dirOp)
            if (!mvSensor.GetSensor( dir ))
                return false;

        return true;
    }

    private void SetDirection()
    {
        Vector2 randDir = dirOp[Random.Range( 0, 4 )];

        int attempts = 0;

        while(mvSensor.GetSensor( randDir ))
        {
            randDir = dirOp[Random.Range( 0, 4 )];

            attempts++;
            if (attempts >= 5)
            {
                direction = Vector2.zero;

                break;
            }
        }
            
        direction = randDir;
    }
}
