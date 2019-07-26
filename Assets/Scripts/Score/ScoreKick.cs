using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKick : MonoBehaviour
{
    public bool canKick { get; private set; }
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Button scoreButton;
    [SerializeField]
    private int requiredPoints;

    private Score cookies;

    // Start is called before the first frame update
    void Start()
    {
        canKick = false;

        scoreText.text = "OFF";

        scoreButton.gameObject.SetActive( false );

        cookies = GameObject.FindWithTag( "ScoreCookie" ).GetComponent<Score>();

    }

    private void Update()
    {
        if (CanUpgrade() && !canKick)
            scoreButton.gameObject.SetActive( true );
        else
            scoreButton.gameObject.SetActive( false );
    }

    private bool CanUpgrade()
    {
        if (cookies.scorePoints >= requiredPoints)
            return true;
        else return false;
    }

    public void OnClick()
    {
        scoreText.text = "ON";

        cookies.RemovePoints( requiredPoints );

        GameObject.FindWithTag( "Player" ).GetComponent<KickCakes>().canKick = true;

        canKick = true;
    }
}
