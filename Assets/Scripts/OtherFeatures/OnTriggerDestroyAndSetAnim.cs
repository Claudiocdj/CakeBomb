using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroyAndSetAnim : OnTriggerDestroy
{
    [SerializeField]
    private GameObject anim;
    [SerializeField]
    private bool InstantiateWhoTriggers = true;

    protected override void Trigger(GameObject other)
    {
        if(CheckIfOtherCanDestroy( other )){
            if (InstantiateWhoTriggers)
                InstantiateAnim( other );

            else
                InstantiateAnim( gameObject );

            base.Trigger( other );
        }
    }

    private bool CheckIfOtherCanDestroy(GameObject other)
    {
        ObjMoveTowardSomething move = other.GetComponent<ObjMoveTowardSomething>();

        if (move && move.somethingTag == gameObject.tag)
            return true;

        else return false;
    }

    private void InstantiateAnim(GameObject obj)
    {
        GameObject objAnim = Instantiate( anim,
        obj.transform.position, Quaternion.identity );

        objAnim.transform.parent = obj.transform;
    }
}
