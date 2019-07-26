using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( InvencibilityOnDamage ) )]
public class PlayerGetShieldCharges : MonoBehaviour
{
    private InvencibilityOnDamage inv;

    private void Start()
    {
        Debug.Log( GameObject.FindWithTag( "ScoreShield" )
            .GetComponent<Score>().scorePoints );

        inv.charges = GameObject.FindWithTag( "ScoreShield" )
            .GetComponent<Score>().scorePoints;
    }
}
