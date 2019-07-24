using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGridObjectsByNumber : CreateGridObjects
{
    [SerializeField]
    private int number;

    protected override void Awake()
    {
        base.Awake();

        CreateObjects( number );
    }
}
