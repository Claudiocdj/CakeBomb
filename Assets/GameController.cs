using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public string nextLevelName { get; private set; }

    public void SetFirstLevel()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy( gameObject );

        DontDestroyOnLoad( this );

        nextLevelName = "1-1";

        SceneManager.LoadScene( "ShowLevel" );
    }

    public void LoadNextLevel()
    {
        int nextSceneId = SceneManager.GetSceneByName(nextLevelName).buildIndex;

        SceneManager.LoadScene( nextLevelName );

        Debug.Log( nextSceneId );

        Scene scene = SceneManager.GetSceneByBuildIndex( nextSceneId + 1 );

        if(scene != null)
            nextLevelName = scene.name;
    }

    public void LoadBlackScreen()
    {
        SceneManager.LoadScene( "ShowLevel" );
    }
}
