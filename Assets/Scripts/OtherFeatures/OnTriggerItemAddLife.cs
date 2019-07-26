using UnityEngine;

public class OnTriggerItemAddLife : OnTriggerItem
{
    protected override void Trigger(GameObject other)
    {
        GameObject.FindWithTag( "ScoreLives" )
            .GetComponent<Score>().AddPoints( 1 );

        base.Trigger( other );
    }
}
