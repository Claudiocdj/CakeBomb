using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    [SerializeField]
    private int gridSizeX;
    [SerializeField]
    private int gridSizeY;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject boxPrefab;

    [SerializeField]
    [Range( 0, 100 )]
    private int boxOccupancy;

    [SerializeField]
    private List<Vector2> prohibitedPos;

    private GameObject[,] grid;

    void Awake()
    {
        grid = new GameObject[gridSizeX, gridSizeY];

        SetPrefabs();
    }

    private void SetPrefabs()
    {
        List<Vector2> blankSpaces = new List<Vector2>();

        SetWalls( blankSpaces );

        SetBoxes( blankSpaces );
    }

    private void SetWalls(List<Vector2> blankSpaces)
    {
        for (int i = 0; i < gridSizeX; i++)
            for (int j = 0; j < gridSizeY; j++)
            {
                if (i % 2 != 0 && j % 2 != 0)
                    AddGrid( wallPrefab, i, j );

                else
                    blankSpaces.Add( new Vector2( i, j ) );
                    
            }
    }

    private void SetBoxes(List<Vector2> blankSpaces)
    {
        RemoveProhibitedPos( blankSpaces );
        
        int amount = ( blankSpaces.Count * boxOccupancy / 100 ) - 1;

        while (amount >= 0)
        {
            int n = Random.Range( 0, blankSpaces.Count );

            Vector2 pos = blankSpaces[n];

            int x = Mathf.RoundToInt( pos.x );
            int y = Mathf.RoundToInt( pos.y );

            AddGrid( boxPrefab, x, y);

            blankSpaces.RemoveAt( n );

            amount--;
        }
    }

    private void RemoveProhibitedPos(List<Vector2> blankSpaces)
    {
        foreach (Vector2 i in prohibitedPos)
            blankSpaces.Remove( i );
    }

    private bool AddGrid(GameObject prefab, int x, int y)
    {
        if ( !CheckGridPos( x,y ) ) return false;

        if (prefab)
        {
            grid[x, y] = Instantiate( prefab,
                new Vector3( x, y, 0 ), Quaternion.identity );

            grid[x, y].transform.parent = transform;
        }
            
        else
            grid[x, y] = null;

        return true;
    }

    public GameObject GetGameObjectByPos(int i, int j)
    {
        if (!CheckGridPos( i,j))
            return null;

        if (grid[i, j] == null) return null;

        return grid[i, j];
    }

    public bool CheckGridPos(int i, int j)
    {
        if (i >= gridSizeX || j >= gridSizeY || i < 0 || j < 0)
            return false;

        return true;
    }
}
