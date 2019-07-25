using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerWin : OnTrigger
{
    protected override void Trigger(GameObject other)
    {
        GameObject.FindWithTag( "GameController" )
            .GetComponent<GameController>().LoadBlackScreen();
    }
}
