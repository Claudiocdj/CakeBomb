using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvencibilityOnDamage : Invencibility
{
    public int charges = 1;

    public bool invensiblyOnStart = false;

    [SerializeField]
    private GameObject animOnDamage;

    protected override void Awake()
    {
        base.Awake();

        if(invensiblyOnStart)
            ActiveInvencibility();
    }

    public virtual void Active()
    {
        charges--;

        if (animOnDamage)
        {
            GameObject objAnim = Instantiate( animOnDamage,
                transform.position, Quaternion.identity );

            objAnim.transform.parent = transform;
        }

        ActiveInvencibility();
    }

    public virtual void AddInvencibility()
    {
        charges++;
    }
}
