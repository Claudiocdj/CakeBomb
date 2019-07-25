using UnityEngine;

public class OnTriggerItemAddShield : OnTriggerItem
{
    protected override void Trigger(GameObject other)
    {
        InvencibilityOnDamage inv = other.gameObject.GetComponent<InvencibilityOnDamage>();

        if (inv)
            inv.AddInvencibility();

        base.Trigger( other );
    }
}
