using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    [SerializeField]
    private MovementSensor mvSensors;

    public Vector2 SmoothMovement(Vector2 direction)
    {
        if(mvSensors.GetSensor( direction ))
        {
            Vector3 otherPos = mvSensors.GetOtherPos( direction );

            if (direction == Vector2.right || direction == Vector2.left)
            {
                float dif = transform.position.y - otherPos.y;

                if (Mathf.Abs( dif ) > 0.3f)
                {
                    if(dif > 0)
                        return Vector2.up;
                    else
                        return Vector2.down;
                }
            }

            if (direction == Vector2.up || direction == Vector2.down)
            {
                float dif = transform.position.x - otherPos.x;

                if (Mathf.Abs( dif ) > 0.3f)
                {
                    if (dif > 0)
                        return Vector2.right;
                    else
                        return Vector2.left;
                }
            }
            return direction;
        }
        else
            return direction;
    }
}
