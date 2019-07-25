using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Explode ) )]
public class OnExplodeAddPoints : MonoBehaviour
{
    [SerializeField]
    private int minPoints = 10;
    [SerializeField]
    private int maxPoints = 50;
    [SerializeField]
    private GameObject pointsPopupPrefab;

    private void Awake()
    {
        GetComponent<Explode>().AddPoints += AddPoints;
    }

    private void AddPoints()
    {
        int n = Random.Range( minPoints, maxPoints );

        if (pointsPopupPrefab)
        {
            GameObject obj = Instantiate( pointsPopupPrefab, transform.position, Quaternion.identity );

            obj.GetComponent<PointsPopup>().SetPointText( n.ToString() );
        }

        GameObject.FindWithTag( "ScoreCookie" )
            .GetComponent<Score>().AddPoints( n );
    }
}
