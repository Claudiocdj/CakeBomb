using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToTradeScreen : Timer
{
    protected override void Zero()
    {
        GameObject.FindWithTag( "GameController" )
            .GetComponent<GameController>().LoadNextLevel();
    }
}
