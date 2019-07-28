using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag( "Player" ).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if(player.position.y <= minY)
            transform.position = new Vector3(
                transform.position.x,
                minY,
                transform.position.z );
        
        else if(player.position.y >= maxY)
            transform.position = new Vector3(
                transform.position.x,
                maxY,
                transform.position.z );
        
        else
            transform.position = new Vector3(
                transform.position.x,
                player.position.y,
                transform.position.z );
    }
}
