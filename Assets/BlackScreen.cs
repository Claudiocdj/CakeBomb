using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    [SerializeField]
    private Text phrase;
    [SerializeField]
    private Text level;
    [SerializeField]
    private string[] phrases = {"to puta, vou matar todo mundo", "cade meu menino"};

    public void Awake()
    {
        phrase.text = GetPhrase();

        level.text = GetLevelName();
    }

    public string GetLevelName()
    {
        return "LEVEL " + GameObject.FindWithTag( "GameController" )
                .GetComponent<GameController>().nextLevelName;
    }

    private string GetPhrase()
    {
        int n = Random.Range( 0, phrases.Length );

        return phrases[n];
    }
}
