using UnityEngine;

public class DestroyCanvas : MonoBehaviour
{
    void Awake()
    {
        GameObject canvas = GameObject.FindWithTag( "Score" );

        if(canvas)
            Destroy( canvas );
    }
}
