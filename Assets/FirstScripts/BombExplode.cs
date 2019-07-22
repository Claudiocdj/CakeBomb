using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    public float bombTime;
    
    public int explosionForce;

    private MapController gridMap;

    private List<Vector2> explosionsPos;

    private List<GameObject> boxesHit;

    private void Awake()
    {
        explosionsPos = new List<Vector2>();

        boxesHit = new List<GameObject>();

        gridMap = GameObject.FindWithTag( "MapController" )
            .GetComponent<MapController>();
    }

    private void Update()
    {
        bombTime -= Time.deltaTime;

        if (bombTime <= 0)
            BombExplosionEffect();
    }

    private void BombExplosionEffect()
    {
        SetExplosionPositions();

        InstantiateExplosions();

        BoxesHit();

        Destroy( gameObject );
    }

    private void SetExplosionPositions()
    {
        int bombPosX = Mathf.RoundToInt( transform.position.x );
        int bombPosY = Mathf.RoundToInt( transform.position.y );

        CheckExplosionPosition( bombPosX, bombPosY );

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckExplosionPosition( bombPosX + i, bombPosY ))
                break;

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckExplosionPosition( bombPosX - i, bombPosY ))
                break;

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckExplosionPosition( bombPosX, bombPosY + i))
                break;

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckExplosionPosition( bombPosX, bombPosY - i))
                break;
    }

    private bool CheckExplosionPosition(int x, int y)
    {
        if (!gridMap.CheckGridPos( x, y )) return false;

        GameObject obj = gridMap.GetGameObjectByPos( x, y );

        if(obj == null)
        {
            explosionsPos.Add( new Vector2( x, y ) );

            return true;
        }

        else if(obj.tag == "Box")
        {
            boxesHit.Add( obj );

            return false;
        }

        return false;
    }

    private void InstantiateExplosions()
    {
        foreach(Vector2 pos in explosionsPos)
            Instantiate( explosionPrefab, pos, Quaternion.identity );
    }

    private void BoxesHit()
    {
        foreach (var obj in boxesHit)
            obj.GetComponent<BoxExplosion>().Explode();
    }
}
