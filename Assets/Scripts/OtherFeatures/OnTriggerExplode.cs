using UnityEngine;

public class OnTriggerExplode : OnTrigger
{
    private InvencibilityOnDamage objInvencibility;

    protected override void Trigger(GameObject other)
    {
        if (!IsInvencible() && !HaveShield())
            GetComponent<Explode>().ExplodeEffect();
    }

    private bool IsInvencible()
    {
        Invencibility inv = GetComponent<Invencibility>();

        if (inv)
        {
            if (inv.isInvencible)
                return true;
            return false;
        }
        else return false;
    }

    private bool HaveShield()
    {
        InvencibilityOnDamage inv = GetComponent<InvencibilityOnDamage>();

        if (inv)
        {
            if (inv.charges > 0)
            {
                inv.Active();

                return true;
            }
            return false;
        }
        else return false;
    }
}
