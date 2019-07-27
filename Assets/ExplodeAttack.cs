using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private float attackDelay;

    private OnTriggerExplode inv;

    private ObjectMoveWithRandomlyFactor move;

    private GridController gridC;

    private Animator anim;

    private float timer;

    private bool endCoroutine = true;

    private void Start()
    {
        inv = GetComponent<OnTriggerExplode>();

        move = GetComponent<ObjectMoveWithRandomlyFactor>();

        gridC = GameObject.FindWithTag( "MapController" ).GetComponent<GridController>();

        timer = Random.Range( attackDelay - 2, attackDelay + 3 );

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(endCoroutine)
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            StartCoroutine( AttackCoroutine() );

            timer = Random.Range( attackDelay - 2, attackDelay + 3 );
        }
    }


    private IEnumerator AttackCoroutine()
    {
        Debug.Log( "começo" );
        endCoroutine = false;

        inv.enabled = false;

        move.enabled = false;

        yield return new WaitForSeconds( 1f );

        anim.SetBool( "Attack", true );

        yield return new WaitForSeconds( 1f );

        InstantiateExplosions();

        yield return new WaitForSeconds( 1f );
        
        anim.SetBool( "Attack", false );

        yield return new WaitForSeconds( 1f );

        Debug.Log( "termino" );
        inv.enabled = true;

        move.enabled = true;

        endCoroutine = true;
    }

    private void InstantiateExplosions()
    {
        List<Vector3> expPos = GetExplosionsPositions();

        Debug.Log( expPos.Count );

        foreach (Vector3 pos in expPos)
        {
            Debug.Log( pos );
            Instantiate( explosionPrefab, pos, Quaternion.identity );
        }
    }

    private List<Vector3> GetExplosionsPositions()
    {
        List<Vector3> expPos = new List<Vector3>();

        Vector3 pos = new Vector2(
            Mathf.RoundToInt( transform.position.x ),
            Mathf.RoundToInt( transform.position.y )
            );
        
        GameObject obj;

        for (int i = 1; i < 10; i++)
        {
            obj = gridC.GetObj( new Vector2( pos.x + i, pos.y ) );
            if (obj) Debug.Log( obj.tag );
            else Debug.Log( "null" );
            if (obj && obj.tag != "Wall")
                expPos.Add( new Vector2( pos.x + i, pos.y ) );

            else break;
        }

        for (int i = 1; i < 10; i++)
        {
            obj = gridC.GetObj( new Vector2( pos.x - i, pos.y ) );
            if (obj) Debug.Log( obj.tag );
            else Debug.Log( "null" );
            if (obj && obj.tag != "Wall")
                expPos.Add( new Vector2( pos.x - i, pos.y ) );

            else break;
        }

        for (int i = 1; i < 10; i++)
        {
            obj = gridC.GetObj( new Vector2( pos.x, pos.y - i ) );
            if (obj) Debug.Log( obj.tag );
            else Debug.Log( "null" );
            if (obj && obj.tag != "Wall")
                expPos.Add( new Vector2( pos.x, pos.y - i ) );

            else break;
        }

        for (int i = 1; i < 10; i++)
        {
            obj = gridC.GetObj( new Vector2( pos.x, pos.y + i ) );
            if (obj) Debug.Log( obj.tag );
            else Debug.Log( "null" );
            if (obj && obj.tag != "Wall")
                expPos.Add( new Vector2( pos.x, pos.y + i ) );

            else break;
        }

        Debug.Log( expPos.Count );

        return expPos;
    }
}
