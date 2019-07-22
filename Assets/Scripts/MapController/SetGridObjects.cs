using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SetGridObjects : GridInstantiator
{
    [SerializeField]
    protected List<Vector2> prohibitedPos;

    protected void CreateObjects(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            int n = Random.Range( 0, gridC.groundsPos.Count );

            Vector2 pos = gridC.groundsPos[n];

            if (prohibitedPos.Contains( pos ))
                continue;

            int x = Mathf.RoundToInt( pos.x );
            int y = Mathf.RoundToInt( pos.y );

            InstantiateObj( objectPrefab, x, y );

            gridC.groundsPos.RemoveAt( n );
        }
    }
}
