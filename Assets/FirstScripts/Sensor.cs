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
        Debug.Log( "Trigger em " + gameObject.name );
        foreach(var l in layers)
            if(other.gameObject.tag == l)
            {
                Debug.Log( gameObject.name + " entrando em " + other.gameObject.name );

                sensorCount++;

                otherPos = other.gameObject.transform.position;
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log( "Saindo em " + gameObject.name );
        foreach (var l in layers)
            if (other.gameObject.tag == l)
            {
                Debug.Log( gameObject.name + " saindo de " + other.gameObject.name );

                sensorCount--;
            }
                
    }
}
