using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject bombPrefab;

    private void Update()
    {
        if (Input.GetKeyDown( KeyCode.Z ))
        {
            float x = Mathf.Round( transform.position.x );

            float y = Mathf.Round( transform.position.y );

            Instantiate( bombPrefab, new Vector3( x, y, 0 ), Quaternion.identity );
        }
    }
}
