using UnityEngine;

public class InputDropBomb : MonoBehaviour
{
    [SerializeField]
    private KeyCode dropBombButton = KeyCode.Z;

    [SerializeField]
    private GameObject bombPrefab;

    private void Update()
    {
        if (Input.GetKeyDown( dropBombButton ))
        {
            float x = Mathf.Round( transform.position.x );

            float y = Mathf.Round( transform.position.y );

            Instantiate( bombPrefab, new Vector3( x, y, 0 ), Quaternion.identity );
        }
    }
}
