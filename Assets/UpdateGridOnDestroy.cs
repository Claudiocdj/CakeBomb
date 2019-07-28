using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGridOnDestroy : TimerToDestroy
{
    private GridController gridC;

    protected override void Start()
    {
        gridC = GameObject.FindWithTag( "MapController" )
            .GetComponent<GridController>();

        base.Start();
    }

    protected override void Zero()
    {
        gridC.SetGround( transform.position );

        base.Zero();
    }
}
