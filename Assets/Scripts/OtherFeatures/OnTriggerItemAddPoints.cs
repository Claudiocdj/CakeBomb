using UnityEngine;

public class OnTriggerItemAddPoints : OnTriggerItem
{
    [SerializeField]
    private int minCoins;
    [SerializeField]
    private int maxCoins;
    [SerializeField]
    private GameObject pointsPopupPrefab;


    protected override void Trigger(GameObject other)
    {
        int n = Random.Range( minCoins, maxCoins+1 );

        GameObject.FindWithTag( "ScoreCookie" )
            .GetComponent<Score>().AddPoints( n );

        GameObject.FindWithTag( "ScoreCookie" ).GetComponent<AudioSource>().Play();

        if (pointsPopupPrefab)
        {
            GameObject obj = Instantiate( pointsPopupPrefab, transform.position, Quaternion.identity );

            obj.GetComponent<PointsPopup>().SetPointText( n.ToString() );
        }

        base.Trigger( other );
    }
}
