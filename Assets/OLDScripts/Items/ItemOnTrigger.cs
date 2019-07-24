using System.Collections;
using System;
using UnityEngine;

public class ItemOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string[] tagsWithTrigger;

    public event Action OnTrigger = delegate { };

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(var tag in tagsWithTrigger)
            if(other.gameObject.tag == tag)
            {
                OnTrigger();
            }
    }
}
