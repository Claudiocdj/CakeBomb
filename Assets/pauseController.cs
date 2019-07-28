using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    [SerializeField]
    private KeyCode button = KeyCode.P;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown( button ))
            Pause();

    }

    void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            AudioListener.volume = 1f;
        }
        else
        {
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
        }
            

        isPaused = !isPaused;
    }
}
