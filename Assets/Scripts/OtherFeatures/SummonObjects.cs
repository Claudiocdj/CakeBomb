using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject objPrefab;
    [SerializeField]
    private int minTimeToSummon;
    [SerializeField]
    private int maxTimeToSummon;

    private List<Vector3> positions = new List<Vector3>()
    { Vector3.up, Vector3.left, Vector3.right, Vector3.down };

    private float timer;

    private GridController gridC;

    private GridMovement move;

    private void Start()
    {
        timer = Random.Range( minTimeToSummon, maxTimeToSummon + 1 );

        gridC = GameObject.FindWithTag( "MapController" ).GetComponent<GridController>();

        move = GetComponent<GridMovement>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Vector2 dir = FindNewDirection();

            if(dir != Vector2.zero && objPrefab != null)
            {
                Vector3 posInt = new Vector2(
                    Mathf.RoundToInt(transform.position.x),
                    Mathf.RoundToInt( transform.position.y )
                    );

                Vector3 pos = FindNewDirection() + posInt;

                Instantiate( objPrefab, pos, Quaternion.identity );
            }

            timer = Random.Range( minTimeToSummon, maxTimeToSummon + 1 );
        }
    }

    protected Vector3 FindNewDirection()
    {
        int n;

        List<Vector3> localPos = new List<Vector3>( positions );

        while (localPos.Count > 0)
        {
            n = Random.Range( 0, localPos.Count );

            GameObject obj = gridC.GetObj( transform.position + localPos[n] );

            if (obj != null && obj.tag == "Ground")
                return localPos[n];

            else
                localPos.RemoveAt( n );
        }

        return Vector3.zero;
    }


}
