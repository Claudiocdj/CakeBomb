using UnityEngine;

public class TimerToDestroy : Timer
{
    protected override void Zero()
    {
        Destroy(gameObject);
    }
}
