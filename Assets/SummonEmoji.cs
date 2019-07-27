using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEmoji : MonoBehaviour
{
    [SerializeField]
    private float time = 5;

    private Animator anim;

    private float timer;

    [SerializeField]
    private GameObject emojiSadPrefab;
    [SerializeField]
    private GameObject emojiHappyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (anim.GetBool( "Open" )) {
            Instantiate( emojiHappyPrefab, transform.position, Quaternion.identity );

            timer = 999;
        };

        if (timer <= 0)
        {
            Instantiate( emojiSadPrefab, transform.position, Quaternion.identity );

            timer = Random.Range( time - 3, time + 4 );
        }
    }

}
