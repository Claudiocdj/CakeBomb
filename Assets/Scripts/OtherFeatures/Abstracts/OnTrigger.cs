using UnityEngine;

public abstract class OnTrigger : MonoBehaviour
{
    [SerializeField]
    private string[] tagWithCollide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var tag in tagWithCollide)
            if (other.gameObject.tag == tag)
                Trigger( other.gameObject );
    }

    protected abstract void Trigger(GameObject other);
}
