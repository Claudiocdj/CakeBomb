using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    [SerializeField]
    private float time = 1f;

    private float counter;

    private void Awake()
    {
        counter = time;
    }

    private void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
            Zero();
    }

    protected abstract void Zero();
}
