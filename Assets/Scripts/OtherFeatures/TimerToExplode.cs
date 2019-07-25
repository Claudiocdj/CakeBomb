using UnityEngine;

[RequireComponent(typeof(Explode))]
public class TimerToExplode : Timer
{
    protected override void Zero()
    {
        GetComponent<Explode>().ExplodeEffect();
    }
}
