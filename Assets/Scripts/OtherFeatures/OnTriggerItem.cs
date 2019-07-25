using UnityEngine;

public class OnTriggerItem : OnTrigger
{
    [SerializeField]
    private GameObject animPrefab;

    protected override void Trigger(GameObject other)
    {
        //som de pegou item

        if (animPrefab)
            Instantiate( animPrefab, transform.position, Quaternion.identity );

        Destroy( gameObject );
    }
}
