using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public string nextLevelName { get; private set; }

    private string[] levelsName = { "1-1", "1-2" };

    private int currentLevelId = 0;

    private void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy( gameObject );

        DontDestroyOnLoad( this );
    }

    public void SetFirstLevel()
    {
        currentLevelId = 0;

        nextLevelName = levelsName[0];

        SceneManager.LoadScene( "ShowLevel" );
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene( nextLevelName );

        currentLevelId++;

        nextLevelName = levelsName[currentLevelId];
    }

    public void LoadBlackScreen()
    {
        SceneManager.LoadScene( "ShowLevel" );
    }

    public void LoadFirstScreen()
    {
        SceneManager.LoadScene( "FirstScene" );
    }
}
