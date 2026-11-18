using UnityEngine;

[CreateAssetMenu(fileName = "Hat", menuName = "Baffs/Hat")]
public class Hat : BaffByChance
{
    [SerializeField] float resultKoef;
    protected override void Activated()
    {
        Debug.Log("Hat Baff activated");
        BaffVisualization.ShowBaffActivity(this.name, true);
    }
    protected override void Deactivated()
    {
        Debug.Log("Hat Baff " + (PointsManager.totalGainedPoints - lastScore).ToString());
        //PointsManager.AddToScore((int)((PointsManager.totalGainedPoints - lastScore) * (resultKoef - 1)));//как нибудь показать что это очки от баффа
        BaffVisualization.AddPointsByBaff(this.name, (int)((PointsManager.totalGainedPoints - lastScore) * (resultKoef - 1)));
        BaffVisualization.ShowBaffActivity(this.name, false);
    }
}