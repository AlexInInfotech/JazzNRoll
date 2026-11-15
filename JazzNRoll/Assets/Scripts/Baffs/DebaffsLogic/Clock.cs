using UnityEngine;


[CreateAssetMenu(fileName = "Clock", menuName = "Debaffs/Clock")]
public class Clock : Baff
{
    [SerializeField] int deltaScore;
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
        Debug.Log("Clock");
        lastScore = PointsManager.totalGainedPoints;

        BaffVisualization.AddRollsByBaff(this.name, -1);

    }
}
