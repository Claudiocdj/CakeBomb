using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : UpdateGridOnExplode
{
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private int explosionForce;
    [SerializeField]
    private string[] blokingTags;
    [SerializeField]
    private string[] destroyedTags;

    public List<Vector2> explosionsPos { get; private set; }

    public List<GameObject> destroyedObj { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();

        explosionsPos = new List<Vector2>();

        destroyedObj = new List<GameObject>();
    }

    public override void ExplodeEffect()
    {
        DefineExplosionLocations();

        //Instantiate explosions prefab
        foreach (Vector2 pos in explosionsPos)
            Instantiate( explosionPrefab, pos, Quaternion.identity );

        //Explode found objects
        foreach (var obj in destroyedObj)
            obj.GetComponent<Explode>().ExplodeEffect();

        base.ExplodeEffect();
    }

    private void DefineExplosionLocations()
    {
        int bombPosX = Mathf.RoundToInt( transform.position.x );
        int bombPosY = Mathf.RoundToInt( transform.position.y );

        CheckGridPos( bombPosX, bombPosY );

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckGridPos( bombPosX + i, bombPosY ))
                break;

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckGridPos( bombPosX - i, bombPosY ))
                break;

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckGridPos( bombPosX, bombPosY + i ))
                break;

        for (int i = 1; i < explosionForce + 1; i++)
            if (!CheckGridPos( bombPosX, bombPosY - i ))
                break;
    }

    private bool CheckGridPos(int i, int j)
    {
        GameObject obj = gridC.GetObj(new Vector2(i, j));

        if (obj != null)
        {
            foreach (var tag in blokingTags)
                if (obj.tag == tag)
                    return false;

            foreach (var tag in destroyedTags)
                if (obj.tag == tag)
                {
                    destroyedObj.Add( obj );

                    return false;
                }

            explosionsPos.Add( new Vector2( i, j ) );

            return true;
        }
        else
            return false;
    }
}
