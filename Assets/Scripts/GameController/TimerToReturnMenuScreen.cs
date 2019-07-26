using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToReturnMenuScreen : Timer
{
    protected override void Zero()
    {
        GameObject.FindWithTag( "GameController" )
            .GetComponent<GameController>().SetMenuScreen();
    }
}
