using System;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public event Action SetExplodeAnim = delegate { };

    public event Action DropItem = delegate { };

    public event Action AddPoints = delegate { };

    public virtual void ExplodeEffect()
    {
        SetExplodeAnim();

        DropItem();

        AddPoints();
        
        Destroy( gameObject );
    }
}
