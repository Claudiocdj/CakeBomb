using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected bool isMoving;
    [SerializeField]
    protected string[] tagsWithCollide = { "Wall", "Bomb", "Box" };

    protected GridController gridC;

    private float inverseMoveTime;
    [SerializeField]
    private float timeToNextBlock = 1f;

    protected virtual void Start()
    {
        gridC = GameObject.FindWithTag("MapController")
            .GetComponent<GridController>();

        inverseMoveTime = 1f / timeToNextBlock;
    }

    protected void Move(Vector3 direction)
    {
        Vector2 end = transform.position + direction;

        StartCoroutine( SmoothMovement( end ) );
    }

    protected bool CanMove(Vector3 end)
    {
        GameObject obj = gridC.GetObj( end );

        if (obj == gameObject) return true;

        //se o destino fica dentro do mapa
        if (obj != null)
        {
            //se tem algum objeto no destino
            foreach (var tag in tagsWithCollide)
                if (obj.tag == tag)
                    return false;

            return true;
        }
        else
            return false;
    }

    private IEnumerator SmoothMovement(Vector3 end)
    {
        isMoving = true;

        Vector3 start = transform.position;

        float sqrRemainingDistance = ( transform.position - end ).sqrMagnitude;

        //enquanto nao chega no destino
        while (sqrRemainingDistance > float.Epsilon)
        {
            if (CanMove( end ))
            {
                FrameMove( end );

                sqrRemainingDistance = ( transform.position - end ).sqrMagnitude;
            }
            else
            {
                ReturnToOrigin( start );

                break;
            }
                
            yield return null;
        }

        isMoving = false;
    }

    private void ReturnToOrigin(Vector2 start)
    {
        transform.position = start;

        isMoving = false;
    }

    private void FrameMove(Vector2 end)
    {
        Vector3 newPostion = Vector3.MoveTowards(
                transform.position, end, inverseMoveTime * Time.deltaTime );

        transform.position = newPostion;
    }
}
