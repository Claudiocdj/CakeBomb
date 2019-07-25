using System.Collections.Generic;
using UnityEngine;

public abstract class CreateGridObjects : GridInstantiator
{
    [SerializeField]
    protected List<Vector2> prohibitedPos;

    protected void CreateObjects(int amount)
    {
        int error = 0;

        while(amount > 0)
        {
            int n = Random.Range( 0, gridC.groundsPos.Count );

            Vector2 pos = gridC.groundsPos[n];

            if (prohibitedPos.Contains( pos ))
            {
                error++;

                if (error >= 100)
                    break;

                continue;
            }

            int x = Mathf.RoundToInt( pos.x );
            int y = Mathf.RoundToInt( pos.y );

            InstantiateObj( objectPrefab, x, y );

            gridC.groundsPos.RemoveAt( n );

            amount--;
        }
    }
}
