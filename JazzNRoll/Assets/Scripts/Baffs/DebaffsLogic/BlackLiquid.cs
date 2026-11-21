using UnityEngine;

[CreateAssetMenu(fileName = "BlackLiquid", menuName = "Debaffs/BlackLiquid")]
public class BlackLiquid : BaffByChance
{
    protected override void Activated()
    {
        BaffVisualization.AddPointsByBaff(this.name, -PointsManager.GetScore());

    }
}
