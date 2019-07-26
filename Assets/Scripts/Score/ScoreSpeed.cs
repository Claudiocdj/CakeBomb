using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpeed : ScoreWithButton
{
    public override void OnClick()
    {
        GameObject.FindWithTag( "Player" ).GetComponent<Movement>()
            .speed += 0.1f;

        base.OnClick();
    }
}
