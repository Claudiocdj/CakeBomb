using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    private SmoothMove smoothMovement;

    private void Awake()
    {
        smoothMovement = GetComponent<SmoothMove>();
    }

    protected void Move(Vector3 direction)
    {
        if (smoothMovement && direction != Vector3.zero)
            direction = smoothMovement.SmoothMovement( direction );

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
