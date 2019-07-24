using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimatorFourPosController : MonoBehaviour
{
    private Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected void SetAnimation(Vector2 dir)
    {
        anim.SetFloat("dirX", dir.x );

        anim.SetFloat( "dirY", dir.y );
    }
}
