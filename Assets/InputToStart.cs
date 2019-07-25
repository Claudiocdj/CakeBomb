using UnityEngine;

public class InputToStart : MonoBehaviour
{
    [SerializeField]
    private KeyCode init = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown( init ))
            GameObject.FindWithTag("GameController")
                .GetComponent<GameController>().SetFirstLevel();
    }
}
