using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallsAndGround : GridInstantiator
{
    [SerializeField]
    private GameObject invisibleWallPrefab;
    [SerializeField]
    private List<Vector2> invisibleWallsPos;

    protected override void Awake()
    {
        base.Awake();

        CreateWalls();
    }

    private void CreateWalls()
    {
        for (int i = 0; i < gridC.sizeX; i++)
            for (int j = 0; j < gridC.sizeY; j++)
            {
                if (invisibleWallsPos.Contains( new Vector2( i, j ) ))
                    InstantiateObj( invisibleWallPrefab, i, j );

                else if (i % 2 != 0 && j % 2 != 0)
                    InstantiateObj( objectPrefab, i, j );
                
                else
                    gridC.SetGround(new Vector2(i,j));
            }
    }
}
