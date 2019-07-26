using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScoreOnText : MonoBehaviour
{
    [SerializeField]
    private Text highscoreText;

    void Start()
    {
        highscoreText.text = "high score: " + PlayerPrefs.GetInt( "HighScore", 0 );
    }
}
