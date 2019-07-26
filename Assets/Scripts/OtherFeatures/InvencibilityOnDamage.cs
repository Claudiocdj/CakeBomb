using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvencibilityOnDamage : Invencibility
{
    public int charges = 1;

    public bool invensiblyOnStart = false;

    protected override void Awake()
    {
        base.Awake();

        if(invensiblyOnStart)
            ActiveInvencibility();
    }

    public virtual void Active()
    {
        charges--;

        ActiveInvencibility();
    }

    public virtual void AddInvencibility()
    {
        charges++;
    }
}
