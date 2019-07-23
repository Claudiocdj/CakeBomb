using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public int sizeX;
    public int sizeY;
    public GameObject[,] grid;
    public List<Vector2> groundsPos { get; set; }

    public bool useGizmos = false;

    public GameObject ground { get; set; }
    
    void Awake()
    {
        groundsPos = new List<Vector2>();

        grid = new GameObject[sizeX, sizeY];
    }

    private bool CheckPos(int i, int j)
    {
        if (i >= sizeX ||
            j >= sizeY ||
            i < 0 || j < 0)
            return false;

        return true;
    }

    public GameObject GetObj(int i, int j)
    {
        if(CheckPos(i,j))
            return grid[i, j];

        return null;
    }

    public GameObject GetObj(Vector2 pos)
    {
        int i = Mathf.RoundToInt( pos.x );
        int j = Mathf.RoundToInt( pos.y );

        if (CheckPos( i, j ))
            return grid[i, j];

        return null;
    }

    public GameObject SetObj(GameObject obj, int i, int j)
    {
        if (CheckPos( i, j ))
            grid[i, j] = obj;

        return null;
    }

    public GameObject SetObj(GameObject obj, Vector2 pos)
    {
        int i = Mathf.RoundToInt( pos.x );
        int j = Mathf.RoundToInt( pos.y );

        if (CheckPos( i, j ))
            grid[i, j] = obj;

        return null;
    }

    public void SetGround(int i, int j)
    {
        if (CheckPos( i, j ))
            grid[i, j] = ground;
    }

    private void OnDrawGizmos()
    {
        if (!useGizmos) return;

        for (int i = 0; i < sizeX; i++)
            for(int j = 0; j < sizeY; j++)
            {
                Gizmos.color = new Color( 0, 0, 0, 1f );

                if (grid[i, j].tag == "Wall")
                    Gizmos.color = new Color( 1, 0, 0, .5f );

                if (grid[i, j].tag == "Ground")
                    Gizmos.color = new Color( 0, 1, 0, .5f );

                if (grid[i, j].tag == "Box")
                    Gizmos.color = new Color( 0, 0, 1, .5f );

                if (grid[i, j].tag == "Player")
                    Gizmos.color = new Color( 1, 1, 0, .5f );

                if(grid[i, j].tag == "Bomb")
                    Gizmos.color = new Color( 0, 0, 0, 0.5f );

                if (grid[i, j].tag == "Enemy")
                    Gizmos.color = new Color( 1, 1, 1, .5f );

                Gizmos.DrawCube( new Vector3( i + 0.5f, j + 0.5f, 0f ), Vector3.one );
            }
    }
}
