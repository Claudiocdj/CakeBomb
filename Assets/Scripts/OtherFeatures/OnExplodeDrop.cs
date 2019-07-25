using UnityEngine;

[RequireComponent(typeof( Explode ) )]
public class OnExplodeDrop : InstantiateObject
{
    private void Awake()
    {
        GetComponent<Explode>().DropItem += InstantiateObj;
    }
}
