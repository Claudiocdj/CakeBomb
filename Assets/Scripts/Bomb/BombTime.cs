using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTime : MonoBehaviour
{
    [SerializeField]
    private float time = 1f;

    private float counter;

    private void Awake()
    {
        counter = time;
    }

    private void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
            GetComponent<BombExplosion>().ExplodeEffect();
    }
}
