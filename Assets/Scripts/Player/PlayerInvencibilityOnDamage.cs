using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvencibilityOnDamage : InvencibilityOnDamage
{
    public override void Active()
    {
        GameObject.FindWithTag( "ScoreShield" ).GetComponent<Score>().RemovePoints( 1 );

        base.Active();
    }

    public override void AddInvencibility()
    {
        GameObject.FindWithTag( "ScoreShield" ).GetComponent<Score>().AddPoints( 1 );

        base.AddInvencibility();
    }
}
