using UnityEngine;

public class OnTriggerItemAddLife : OnTriggerItem
{
    protected override void Trigger(GameObject other)
    {


        //isso aqui embaixo soh que pra lives

        //InvencibilityOnDamage inv = other.gameObject.GetComponent<InvencibilityOnDamage>();

        //if (inv)
        //    inv.AddInvencibility();

        base.Trigger( other );
    }
}
