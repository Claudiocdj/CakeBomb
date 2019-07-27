using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveTowardSomething : ObjectMoveInLine
{
    [SerializeField]
    private int searchDistance = 5;
    [SerializeField]
    private string[] tagsWithBlokingSearch = { "Box" };
    [SerializeField]
    private GameObject animWhenFinded;

    public string somethingTag = "Bomb";

    private bool finded = false;

    protected override void Update()
    {
        if (!isMoving)
        {
            direction = SearchForSomething();

            if (direction != Vector3.zero)
            {
                if(finded == false && animWhenFinded != null)
                    InstantiateAnim();

                finded = true;
            }
            else finded = false;
        }

        base.Update();
    }

    private Vector2 SearchForSomething()
    {
        Vector2 pos = new Vector2(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt( transform.position.y )
            );

        if (CheckLine( pos, Vector2.up ))
            return Vector2.up;

        if (CheckLine( pos, Vector2.down ))
            return Vector2.down;

        if (CheckLine( pos, Vector2.left ))
            return Vector2.left;

        if (CheckLine( pos, Vector2.right ))
            return Vector2.right;

        return Vector2.zero;
    }

    private bool CheckLine(Vector2 pos, Vector2 dir)
    {
        GameObject obj;

        for (int i = 1; i < searchDistance + 1; i++)
        {
            obj = gridC.GetObj( new Vector2( pos.x + (i * dir.x), pos.y + (i * dir.y) ) );

            if (obj)
            {
                if (obj.tag == somethingTag)
                    return true;

                foreach (var tag in tagsWithBlokingSearch)
                    if (obj.tag == tag)
                        return false;
            }
        }

        return false;
    }

    private void InstantiateAnim()
    {
        GameObject obj = Instantiate( animWhenFinded,
        transform.position, Quaternion.identity );

        obj.transform.parent = transform;
    }
    
}
