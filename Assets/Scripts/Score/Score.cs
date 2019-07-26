using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int startScorePoints;
    [SerializeField]
    private string initText;

    public int scorePoints { get; private set; }

    private HighScore highScore;

    protected virtual void Start()
    {
        highScore = GetComponent<HighScore>();

        scorePoints = 0;

        AddPoints( startScorePoints);
    }

    public void AddPoints(int c)
    {
        scorePoints += c;

        highScore.AddCurrentScore( c );

        scoreText.text = initText + scorePoints.ToString();
    }

    public void RemovePoints(int c)
    {
        scorePoints -= c;

        scoreText.text = initText + scorePoints.ToString();
    }
}
