using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGridExplode : Explode
{
    protected GridController gridC;

    protected virtual void Awake()
    {
        gridC = GameObject.FindWithTag( "MapController" )
            .GetComponent<GridController>();
    }

    public override void ExplodeEffect()
    {
        int x = Mathf.RoundToInt( transform.position.x );
        int y = Mathf.RoundToInt( transform.position.y );

        gridC.SetGround( x, y );

        base.ExplodeEffect();
    }
}

