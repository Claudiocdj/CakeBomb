using UnityEngine;

[RequireComponent( typeof( Explode ) )]
public class OnExplodeSetAnimation : InstantiateObject
{
    private void Awake()
    {
        GetComponent<Explode>().SetExplodeAnim += InstantiateObj;
    }
}
