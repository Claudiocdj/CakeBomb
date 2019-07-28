using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    [SerializeField]
    private KeyCode button = KeyCode.M;

    private bool isMute = false;

    private void Update()
    {
        if (Input.GetKeyDown( button ))
            AllAudios();

    }

    void AllAudios()
    {
        if (isMute)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;

        isMute = !isMute;
    }
}
