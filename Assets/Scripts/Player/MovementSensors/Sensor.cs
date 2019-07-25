using UnityEngine;

public class Sensor : MonoBehaviour
{

    public Vector3 otherPos;

    private string[] layers;

    [SerializeField]
    private int sensorCount = 0;

    public bool IsTrigger()
    {
        if (sensorCount > 0)
            return true;
        else
            return false;
    }

    public void SetLayers(string[] n)
    {
        layers = n;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(var l in layers)
            if(other.gameObject.tag == l)
            {
                sensorCount++;

                otherPos = other.gameObject.transform.position;
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (var l in layers)
            if (other.gameObject.tag == l)
                sensorCount--;
                
    }
}
