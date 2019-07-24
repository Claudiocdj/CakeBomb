using UnityEngine;

[RequireComponent(typeof(Explode))]
public class TimerToExplode : MonoBehaviour
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
            GetComponent<Explode>().ExplodeEffect();
    }
}
