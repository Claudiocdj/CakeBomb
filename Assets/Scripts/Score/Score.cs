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

    protected virtual void Start()
    {
        scorePoints = 0;

        AddPoints( startScorePoints);
    }

    public void AddPoints(int c)
    {
        scorePoints += c;

        scoreText.text = initText + scorePoints.ToString();
    }

    public void RemovePoints(int c)
    {
        scorePoints -= c;

        scoreText.text = initText + scorePoints.ToString();
    }
}
