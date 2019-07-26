using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private void Awake()
    {
        HighScore score = GameObject.FindWithTag( "ScoreCookie" )
            .GetComponent<HighScore>();

        scoreText.text = "total cookies: " + score.totalScore;
    }
}
