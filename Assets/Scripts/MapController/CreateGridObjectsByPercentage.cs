using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGridObjectsByPercentage : CreateGridObjects
{
    [SerializeField]
    [Range( 0, 100 )]
    private int boxOccupancy;

    protected override void Awake()
    {
        base.Awake();

        int amount = ( gridC.groundsPos.Count * boxOccupancy / 100 ) - 1;

        CreateObjects( amount );
    }
}
