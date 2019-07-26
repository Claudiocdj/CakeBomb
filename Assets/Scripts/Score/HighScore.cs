using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public int totalScore;

    public int highScore { get; private set; }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt( "HighScore", 0 );

        totalScore = 0;
    }

    public void AddCurrentScore(int n)
    {
        totalScore += n;

        CheckHighScore();
    }

    private void CheckHighScore()
    {
        if(totalScore > highScore)
        {
            highScore = totalScore;

            PlayerPrefs.SetInt( "HighScore", highScore );
        }
    }
}
