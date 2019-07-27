using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartSetAnim : MonoBehaviour
{
    [SerializeField]
    private string affectedTag;
    [SerializeField]
    private GameObject anim;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag( affectedTag );

        foreach(var obj in objs)
        {
            GameObject objAnim = Instantiate( anim,
                obj.transform.position, Quaternion.identity );

            objAnim.transform.parent = obj.transform;
        }
        
    }
}
