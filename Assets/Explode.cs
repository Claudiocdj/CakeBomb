using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public virtual void ExplodeEffect()
    {
        DropOnExplode dropItem = GetComponent<DropOnExplode>();

        if (dropItem != null)
            dropItem.Drop();

        Destroy( gameObject );
    }
}
