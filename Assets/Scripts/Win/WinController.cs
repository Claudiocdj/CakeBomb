using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    private BoxCollider2D bc;

    private Animator anim;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int total = GameObject.FindGameObjectsWithTag( "Enemy" ).Length;

        if (total == 0)
        {
            Win();

            enabled = false;
        }
    }

    private void Win()
    {
        anim.SetBool( "Open", true );

        bc.isTrigger = true;

        bc.offset = new Vector2( 0.5f, 0.75f );

        bc.size = new Vector2( 1f, 0.5f );
    }
}
