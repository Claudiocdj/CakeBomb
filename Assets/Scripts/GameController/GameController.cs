using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    private string[] levelsName = { "1-1"};

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
        return "oi nego";
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
