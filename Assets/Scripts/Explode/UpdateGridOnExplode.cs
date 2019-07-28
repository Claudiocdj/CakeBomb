using UnityEngine;

public class UpdateGridOnExplode : Explode
{
    protected GridController gridC;

    protected virtual void Awake()
    {
        gridC = GameObject.FindWithTag( "MapController" )
            .GetComponent<GridController>();
    }

    public override void ExplodeEffect()
    {
        if(gridC.GetObj(transform.position).tag == gameObject.tag )
            gridC.SetGround( transform.position );

        base.ExplodeEffect();
    }
}

