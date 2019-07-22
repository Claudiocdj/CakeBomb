using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( GridController ) )]
public abstract class GridInstantiator : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectPrefab;

    protected GridController gridC;

    protected virtual void Awake()
    {
        gridC = GetComponent<GridController>();
    }

    protected void InstantiateObj(GameObject prefab, int x, int y)
    {
        gridC.grid[x, y] = Instantiate( prefab, new Vector2( x, y ), Quaternion.identity );

        gridC.grid[x, y].transform.parent = transform;
    }
}
