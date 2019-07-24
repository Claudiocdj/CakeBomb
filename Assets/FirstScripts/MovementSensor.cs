using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSensor : MonoBehaviour
{
    [SerializeField]
    private Sensor rightSensor;
    [SerializeField]
    private Sensor leftSensor;
    [SerializeField]
    private Sensor upSensor;
    [SerializeField]
    private Sensor downSensor;
    
    public string[] layers = { "Wall" };

    private void Awake()
    {
        SetLayersMask();
    }

    private void SetLayersMask()
    {
        rightSensor.SetLayers( layers );
        leftSensor.SetLayers( layers );
        upSensor.SetLayers( layers );
        downSensor.SetLayers(layers);
    }

    public bool GetSensor(Vector2 direction)
    {
        if (direction == Vector2.right)
            return rightSensor.IsTrigger();

        else if (direction == Vector2.left)
            return leftSensor.IsTrigger();

        else if (direction == Vector2.up)
            return upSensor.IsTrigger();

        else if (direction == Vector2.down)
            return downSensor.IsTrigger();

        return false;
    }

    public Vector3 GetOtherPos(Vector2 direction)
    {
        if (direction == Vector2.right)
            return rightSensor.otherPos;

        else if (direction == Vector2.left)
            return leftSensor.otherPos;

        else if (direction == Vector2.up)
            return upSensor.otherPos;

        else if (direction == Vector2.down)
            return downSensor.otherPos;

        return Vector3.zero;
    }
}
