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

    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new GameObject[gridSizeX, gridSizeY];

        SetWalls();

        SetBoxes();
    }

    private void SetWalls()
    {
        for (int i = 0; i < gridSizeX; i++)
            for (int j = 0; j < gridSizeY; j++)
                if (i % 2 != 0 && j % 2 != 0)
                    grid[i, j] = Instantiate( wallPrefab,
                        new Vector3( i, j, 0f ), Quaternion.identity );
    }

    private void SetBoxes()
    {
        int amount = gridSizeX * gridSizeY * boxOccupancy / 100;

        while(amount >= 0)
        {
            int x = Random.Range( 0, gridSizeX );

            int y = Random.Range( 0, gridSizeX );

            if (grid[x, y] == null && 
                !prohibitedPos.Contains(new Vector2( x, y ))){

                grid[x, y] = Instantiate( boxPrefab, 
                    new Vector3( x, y, 0 ), Quaternion.identity );

                amount--;
            }
        }
    }
}
