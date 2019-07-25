using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Invencibility : MonoBehaviour
{
    [SerializeField]
    private float timer;

    public bool isInvencible;

    private SpriteRenderer mySprite;

    protected virtual void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    protected void ActiveInvencibility()
    {
        StartCoroutine( InvensibilityEffect() );
    }

    private IEnumerator InvensibilityEffect()
    {
        isInvencible = true;

        for(int i = 0; i < timer * 5; i++)
        {
            mySprite.color = new Color( 1, 1, 1, 0 );
            yield return new WaitForSeconds( .1f );
            mySprite.color = new Color( 1, 1, 1, 1 );
            yield return new WaitForSeconds( .1f );
        }

        isInvencible = false;
    }
}
