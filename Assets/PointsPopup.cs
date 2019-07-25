using UnityEngine;

public class PointsPopup : TimerToDestroy
{
    [SerializeField]
    private TextMesh pointsText;

    protected override void Awake()
    {
        gameObject.transform.GetChild(0).
        GetComponent<Renderer>().sortingLayerName = "UI";

        base.Awake();
    }

    public void SetPointText(string t)
    {
        pointsText.text = t;
    }
}
