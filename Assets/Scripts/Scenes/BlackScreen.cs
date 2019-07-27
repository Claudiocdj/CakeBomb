using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    [SerializeField]
    private Text phrase;
    [SerializeField]
    private Text level;

    private GameController gm;

    public void Awake()
    {
        gm = GameObject.FindWithTag( "GameController" )
                .GetComponent<GameController>();

        phrase.text = GetPhrase();

        level.text = GetLevelName();
    }

    public string GetLevelName()
    {
        return "LEVEL " + gm.GetCurrentSceneName();
    }

    private string GetPhrase()
    {
        return gm.GetLevelPhrase();
    }
}
