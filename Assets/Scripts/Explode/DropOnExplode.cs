using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( Explode ) )]
public class DropOnExplode : MonoBehaviour
{
    [SerializeField]
    private GameObject objPrefab;

    public void Drop()
    {
        Instantiate( objPrefab, transform.position, Quaternion.identity );
    }
}
