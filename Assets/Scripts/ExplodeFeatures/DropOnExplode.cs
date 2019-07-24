using UnityEngine;

[RequireComponent(typeof( Explode ) )]
public class DropOnExplode : MonoBehaviour
{
    [SerializeField]
    private GameObject objPrefab;

    private void Awake()
    {
        GetComponent<Explode>().DropItem += Drop;
    }

    private void Drop()
    {
        Instantiate( objPrefab, transform.position, Quaternion.identity );
    }
}
