using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( InputControllerMovement ) )]
public class PlayerGetSpeedOnStart : MonoBehaviour
{
    private void Start()
    {
        InputControllerMovement move = GetComponent<InputControllerMovement>();

        move.speed = GameObject.FindWithTag( "ScoreSpeed" )
            .GetComponent<Score>().scorePoints * 0.1f + 2f;
    }
}
