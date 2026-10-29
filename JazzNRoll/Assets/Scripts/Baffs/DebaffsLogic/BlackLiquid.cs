using UnityEngine;

[CreateAssetMenu(fileName = "BlackLiquid", menuName = "Debaffs/BlackLiquid")]
public class BlackLiquid : BaffByChance
{
    protected override void Activated()
    {
        Debug.Log("BlackLiquid");
        //PointsManager.AddToScore(-PointsManager.GetScore());
        BaffVisualization.ShowPointsByBaff(this.name, -PointsManager.GetScore());

    }
}
