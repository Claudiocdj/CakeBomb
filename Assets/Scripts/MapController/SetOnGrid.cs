using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOnGrid : MonoBehaviour
{
    private GridController gridC;

    private Vector2 currentPos;
    [SerializeField]
    private string[] preferenceTags;

    private void Start()
    {
        int x = Mathf.RoundToInt( transform.position.x );
        int y = Mathf.RoundToInt( transform.position.y );

        currentPos = new Vector2( x, y );

        gridC = GameObject.FindWithTag( "MapController" )
            .GetComponent<GridController>();

        if (preferenceTags.Length == 0)
            gridC.SetObj( gameObject, x, y );

        else if (preferenceTags.Length > 0 && CheckPreferenceTags())
            gridC.SetObj( gameObject, x, y );
    }

    void Update()
    {
        int x = Mathf.RoundToInt( transform.position.x );
        int y = Mathf.RoundToInt( transform.position.y );

        if (currentPos != new Vector2( x, y ))
        {
            if (preferenceTags.Length > 0 && !CheckPreferenceTags())
            {
                gridC.SetGround( Mathf.RoundToInt( currentPos.x ),
                Mathf.RoundToInt( currentPos.y ) );

                return;
            }

            GameObject obj = gridC.GetObj( currentPos );

            if (obj.tag != gameObject.tag)
                gridC.SetObj( obj, currentPos );
            else
                gridC.SetGround( Mathf.RoundToInt(currentPos.x),
                Mathf.RoundToInt( currentPos.y) );

            currentPos = new Vector2( x, y );

            gridC.SetObj( gameObject, x, y );
        }
    }

    private bool CheckPreferenceTags()
    {
        GameObject obj = gridC.GetObj( transform.position );

        if (obj)
        {
            foreach (var tag in preferenceTags)
                if (obj.tag == tag)
                    return false;

                else return true;
        }
        return false;
    }
}
