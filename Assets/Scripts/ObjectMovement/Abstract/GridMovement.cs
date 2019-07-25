using System.Collections;
using UnityEngine;

public abstract class GridMovement : MonoBehaviour
{
    [SerializeField]
    private float timeToNextBlock = 1f;
    [SerializeField]
    protected string[] tagsWithCollide = { "Wall", "Bomb", "Box", "Enemy" };

    public bool isMoving { get; private set; }

    protected GridController gridC;

    private float inverseMoveTime;

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

        //if the destination is on the map
        if (obj != null)
        {
            //if have an object in the destination
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

        //while not arriving at the destination
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
