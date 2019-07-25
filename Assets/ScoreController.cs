using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance = null;

    private void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy( gameObject );

        DontDestroyOnLoad( this );
    }
}
