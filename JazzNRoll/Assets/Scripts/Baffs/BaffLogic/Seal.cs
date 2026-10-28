using UnityEngine;

[CreateAssetMenu(fileName = "Seal", menuName = "Baffs/Seal")]
public class Seal : Baff
{
    [SerializeField] byte conditionNum;
    [SerializeField] byte countNum;
    [SerializeField] byte additivePoints;
    public override void ModifyGame()
    {
        if(PointsManager.CountNumInDropped(conditionNum) >= countNum)
            //PointsManager.AddToScore(additivePoints);
            BaffVisualization.ShowPointsByBaff(this.name, additivePoints);

    }
}
