using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExplode : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Explosion")
        {
            GetComponent<BombExplode>().bombTime = 0f;
        }
    }
}
