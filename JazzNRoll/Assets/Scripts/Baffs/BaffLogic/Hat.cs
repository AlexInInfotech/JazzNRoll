using UnityEngine;

[CreateAssetMenu(fileName = "Hat", menuName = "Baffs/Hat")]
public class Hat : BaffByChance
{
    [SerializeField] float resultKoef;
    protected override void Activated()
    {
        BaffVisualization.ShowBaffActivity(this.name, true);
    }
    protected override void Deactivated()
    {
        BaffVisualization.AddPointsByBaff(this.name, (int)((PointsManager.totalGainedPoints - lastScore) * (resultKoef - 1)));
        BaffVisualization.ShowBaffActivity(this.name, false);
    }
}