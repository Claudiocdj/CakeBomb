using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWithButton : Score
{
    [SerializeField]
    private Button scoreButton;
    [SerializeField]
    private Text maxLevelText;
    [SerializeField]
    private int maxScorePoints = 8;
    [SerializeField]
    private float pointsUpgradeFactor = 1.5f;
    [SerializeField]
    private int pointsToNextLevelInitial = 100;

    private int pointsToNextLevel;

    private Score cookies;

    private bool isMax;

    protected override void Start()
    {
        base.Start();

        maxLevelText.gameObject.SetActive( false );

        scoreButton.gameObject.SetActive( false );

        cookies = GameObject.FindWithTag( "ScoreCookie" ).GetComponent<Score>();

        pointsToNextLevel = pointsToNextLevelInitial;
    }

    protected void Update()
    {
        if (CanUpgrade() && !isMax)
            scoreButton.gameObject.SetActive(true);
        else
            scoreButton.gameObject.SetActive( false );
    }                                                                                                                                                 

    private void SetPointsToNextLevel()
    {
        pointsToNextLevel = Mathf
            .RoundToInt( pointsToNextLevel * pointsUpgradeFactor );
    }

    private bool CanUpgrade()
    {
        if (cookies.scorePoints >= pointsToNextLevel)
            return true;
        else return false;
    }

    public void OnClick()
    {
        Debug.Log( "clicou" );

        cookies.RemovePoints( pointsToNextLevel );

        AddPoints(1);

        if (scorePoints >= maxScorePoints)
        {
            maxLevelText.gameObject.SetActive( true );

            isMax = true;
        }

        SetPointsToNextLevel();
    }
}
