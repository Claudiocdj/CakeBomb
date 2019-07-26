using UnityEngine;

public class PointsPopup : TimerToDestroy
{
    [SerializeField]
    private TextMesh pointsText;

    protected override void Start()
    {
        gameObject.transform.GetChild(0).
        GetComponent<Renderer>().sortingLayerName = "UI";

        base.Start();
    }

    public void SetPointText(string t)
    {
        pointsText.text = t;
    }
}
