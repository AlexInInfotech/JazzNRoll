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
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("Razor");
        lastScore = PointsManager.totalGainedPoints;
        DiceManager.AddRolls(-1);
    }
}
