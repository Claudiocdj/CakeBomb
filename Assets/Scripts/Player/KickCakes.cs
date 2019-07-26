using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KickCakes : MonoBehaviour
{
    public bool canKick = false;
    [SerializeField]
    private KeyCode inputButton = KeyCode.X;
    [SerializeField]
    private GameObject kickedBombPrefab;
    
    private Animator anim;

    private GridController gridC;

    private GameObject obj;

    private Vector3 playerDir;

    void Start()
    {
        canKick = GameObject.FindWithTag( "ScoreKick" ).GetComponent<ScoreKick>().canKick;

        anim = GetComponent<Animator>();

        gridC = GameObject.FindWithTag( "MapController" ).GetComponent<GridController>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown( inputButton ) && canKick)
            if (CheckIfHaveBomb())
                KickCake();
    }

    private bool CheckIfHaveBomb()
    {
        playerDir = new Vector2(anim.GetFloat("dirX"), anim.GetFloat( "dirY" ));

        obj = gridC.GetObj( playerDir + transform.position );

        if (obj)
            if (obj.tag == "Bomb")
                return true;

        return false;
    }

    private void KickCake()
    {
        if (!kickedBombPrefab) return;

        GameObject kickedObj = Instantiate( kickedBombPrefab,
            obj.transform.position , Quaternion.identity );

        kickedObj.GetComponent<TimerToExplode>().time = obj.GetComponent<TimerToExplode>().counter;

        kickedObj.GetComponent<ObjectMoveInLineUntilCollide>().direction = playerDir;

        Destroy( obj );
    }
}
