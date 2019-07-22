using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetByNumber : SetGridObjects
{
    [SerializeField]
    private int number;

    protected override void Awake()
    {
        base.Awake();

        CreateObjects( number );
    }
}
