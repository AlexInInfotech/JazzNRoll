using UnityEngine;
[CreateAssetMenu(fileName = "Poker", menuName = "Baffs/Poker")]
public class Poker : Baff
{
    [SerializeField] int deltaScore;
    [SerializeField] int additivePoints;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        BaffVisualization.ShowBaffScore(this.name, PointsManager.totalGainedPoints - lastScore);
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("Poker");
        lastScore = PointsManager.totalGainedPoints;
        //PointsManager.AddToScore(additivePoints);
        BaffVisualization.AddPointsByBaff(this.name, additivePoints);
    }
}
