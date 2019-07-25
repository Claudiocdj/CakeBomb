using UnityEngine;

public class SetObjectOnGrid : MonoBehaviour
{
    [SerializeField]
    private string[] preferenceTags;

    private GridController gridC;

    private Vector2 currentPos;

    private Vector2 newPos;
    
    private void Start()
    {
        gridC = GameObject.FindWithTag( "MapController" )
            .GetComponent<GridController>();

        currentPos = FindCurrentPos();

        if (CanSwapTheObjectOnGrid( currentPos ))
            gridC.SetObj( gameObject, currentPos );
    }

    void Update()
    {
        newPos = FindCurrentPos();

        if (newPos != currentPos)
        {
            if (CanSwapTheObjectOnGrid( currentPos ))
                gridC.SetGround( currentPos );

            if (CanSwapTheObjectOnGrid( newPos ))
                gridC.SetObj( gameObject, newPos );

            currentPos = newPos;
        }
    }

    private bool CanSwapTheObjectOnGrid (Vector2 pos)
    {
        if (preferenceTags.Length == 0)
            return true;

        GameObject obj = gridC.GetObj( pos );

        if (obj)
        {
            foreach (var tag in preferenceTags)
                if (obj.tag == tag)
                    return false;
                else
                    return true;
        }
        return false;
    }

    private Vector2 FindCurrentPos()
    {
        int x = Mathf.RoundToInt( transform.position.x );
        int y = Mathf.RoundToInt( transform.position.y );

        return new Vector2( x, y );
    }
}
