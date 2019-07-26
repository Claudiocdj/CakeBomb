using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Invencibility : MonoBehaviour
{
    [SerializeField]
    protected float timer;

    public bool isInvencible;

    protected SpriteRenderer mySprite;

    protected virtual void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    protected void ActiveInvencibility()
    {
        StartCoroutine( InvencibilityEffect() );
    }

    protected virtual IEnumerator InvencibilityEffect()
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
