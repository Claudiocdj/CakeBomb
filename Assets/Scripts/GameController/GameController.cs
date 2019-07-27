using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    private string[] levelsName = { "1-1", "1-2", "1-3", "1-4", "1-5", "1-6", "1-7", "1-8" };

    private string[] phrases = { "Use suas habilidades de confeiteira e resgate sua irmazinha.",
        "O upgrade de chute custa 1000 cookies.",
        "Para chutar, basta ficar em frente ao bolo e apertar 'X'.",
        "Cuidado com o rato com coroa.",
        "O rato nao era o ultimo boss.",
        "Antes de passar de fase cheque todas as caixas.",
        "Agora os desafios sao maiores.",
        "Chegou o momento"};

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
