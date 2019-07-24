using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof( SmoothMove ) )]
public class Movement : MonoBehaviour
{
    public float speed = 1f;

    private SmoothMove sm;

    private Rigidbody2D myRb;
    
    private void Awake()
    {
        sm = GetComponent<SmoothMove>();

        myRb = GetComponent<Rigidbody2D>();
    }

    protected void Move(Vector3 direction)
    {
        if (sm && direction != Vector3.zero)
            direction = sm.SmoothMovement( direction );

        myRb.velocity = direction * speed;
    }
}
