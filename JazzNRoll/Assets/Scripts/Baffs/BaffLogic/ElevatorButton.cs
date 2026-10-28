using UnityEngine;

[CreateAssetMenu(fileName = "ElevatorButton", menuName = "Baffs/ElevatorButton")]
public class ElevatorButton : Baff
{
    [SerializeField] int additivePoints;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)
            return;
        //PointsManager.AddToScore(additivePoints);
        BaffVisualization.ShowPointsByBaff(this.name, additivePoints);
        lastScore = PointsManager.totalGainedPoints;
    }
}