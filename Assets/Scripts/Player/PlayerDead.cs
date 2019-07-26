using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : Explode
{
    public override void ExplodeEffect()
    {
        Score Scorelives = GameObject.FindWithTag( "ScoreLives" ).GetComponent<Score>();

        ScoreKick scoreKick = GameObject.FindWithTag( "ScoreKick" ).GetComponent<ScoreKick>();

        scoreKick.ResetKick();

        GameController gm = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();

        if (Scorelives.scorePoints > 1)
        {
            Scorelives.RemovePoints( 1 );

            gm.Reload(2f);
        }
        else
            gm.GameOver( 2f );
        
        base.ExplodeEffect();
    }
}
