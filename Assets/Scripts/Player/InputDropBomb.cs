using UnityEngine;

public class InputDropBomb : MonoBehaviour
{
    [SerializeField]
    private KeyCode dropBombButton = KeyCode.Z;

    [SerializeField]
    private GameObject bombPrefab;

    private int amountInstantiate;

    private int amountMax;

    private void Update()
    {
        if (Input.GetKeyDown( dropBombButton ) && CanDrop())
        {
            float x = Mathf.Round( transform.position.x );

            float y = Mathf.Round( transform.position.y );

            Instantiate( bombPrefab, new Vector3( x, y, 0 ), Quaternion.identity );
        }
    }

    private bool CanDrop()
    {
        amountMax = GameObject.FindWithTag( "ScoreCake" )
            .GetComponent<Score>().scorePoints;

        amountInstantiate = GameObject.FindGameObjectsWithTag( "Bomb" ).Length;

        if (amountInstantiate >= amountMax)
            return false;
        else return true;

    }
}
