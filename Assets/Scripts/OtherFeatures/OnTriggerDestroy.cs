using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : OnTrigger
{
    private GridController gridC;
    
    protected override void Trigger(GameObject other)
    {
        gridC = GameObject.FindWithTag( "MapController" )
            .GetComponent<GridController>();

        GameObject obj = gridC.GetObj( transform.position );

        if (obj && obj.tag == gameObject.tag)
            gridC.SetGround( transform.position );

        Destroy( gameObject );
    }
}
