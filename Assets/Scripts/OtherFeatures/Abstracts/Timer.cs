using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    public float time = 1f;

    public float counter;

    protected virtual void Start()
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
