using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WallSetSprite : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> spriteList;

    private void Awake()
    {
        if (spriteList.Count == 0)
            return;

        int n = Random.Range( 0, spriteList.Count );

        GetComponent<SpriteRenderer>().sprite = spriteList[n];
    }
}
