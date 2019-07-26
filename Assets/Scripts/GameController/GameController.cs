using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    private string[] levelsName = { "1-1", "1-2", "1-3", "1-4", "1-5" };

    private string[] phrases = { "Saiam do meu vilarejo",
        "Otimo, agora onde levaram minha irmazinha?",
        "Esses caras destruiram a cidade inteira, nao eh possivel",
        "Para chutar, basta ficar em frente ao bolo e apertar 'X'.",
        "Aquele rato tem um chapeuzinho amarelo na cabeça? kk"};

    private int currentLevelId;

    private void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy( gameObject );

        DontDestroyOnLoad( this );
    }

    public string GetCurrentSceneName()
    {
        return levelsName[currentLevelId];
    }

    public string GetLevelPhrase()
    {
        return phrases[currentLevelId];
    }

    public void SetMenuScreen()
    {
        SceneManager.LoadScene( "FirstScene" );
    }

    public void SetFirstLevel()
    {
        currentLevelId = 0;

        SceneManager.LoadScene( "ShowLevel" );
    }

    public void SetCurrentLevel()
    {
        SceneManager.LoadScene( GetCurrentSceneName() );
    }

    public void Win()
    {
        currentLevelId++;

        if (currentLevelId >= levelsName.Length)
            SceneManager.LoadScene( "Win" );
        else
            SceneManager.LoadScene( "ShowLevel" );
    }

    public void Reload()
    {
        SceneManager.LoadScene( "ShowLevel" );
    }

    public void Reload(float timer)
    {
        StartCoroutine( LoadWithTimer( timer, "ShowLevel" ) );
    }

    public void GameOver(float timer)
    {
        StartCoroutine( LoadWithTimer( timer, "GameOver" ) );
    }

    private IEnumerator LoadWithTimer(float timer, string sceneName)
    {
        yield return new WaitForSeconds( timer );

        SceneManager.LoadScene( sceneName );
    }
}
