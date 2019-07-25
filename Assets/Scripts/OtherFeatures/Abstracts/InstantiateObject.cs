using UnityEngine;

public abstract class InstantiateObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;
    
    protected void InstantiateObj()
    {
        Instantiate( objectPrefab, transform.position, Quaternion.identity );
    }
}
