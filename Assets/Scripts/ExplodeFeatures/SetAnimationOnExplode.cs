using UnityEngine;

[RequireComponent( typeof( Explode ) )]
public class SetAnimationOnExplode : MonoBehaviour
{
    [SerializeField]
    private GameObject animObjectPrefab;

    private void Awake()
    {
        GetComponent<Explode>().SetExplodeAnim += SetAnim;
    }

    private void SetAnim()
    {
        Instantiate( animObjectPrefab, transform.position, Quaternion.identity );
    }
}
