using UnityEngine;

public class OnTriggerItemAddCoins : OnTriggerItem
{
    [SerializeField]
    private int minCoins;
    [SerializeField]
    private int maxCoins;

    protected override void Trigger(GameObject other)
    {
        int n = Random.Range( minCoins, maxCoins+1 );

        Debug.Log( "Add " + n + " cookies!" );

        base.Trigger( other );
    }
}
