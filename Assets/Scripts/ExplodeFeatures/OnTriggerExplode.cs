using UnityEngine;

public class OnTriggerExplode : MonoBehaviour
{
    [SerializeField]
    private string[] tagWithExplode;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(var tag in tagWithExplode)
            if (other.gameObject.tag == tag)
                GetComponent<Explode>().ExplodeEffect();
    }
}
