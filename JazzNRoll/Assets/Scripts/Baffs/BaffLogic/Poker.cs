using UnityEngine;
[CreateAssetMenu(fileName = "Poker", menuName = "Baffs/Poker")]
public class Poker : Baff
{
    [SerializeField] int deltaScore;
    [SerializeField] int extraPoints;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("Poker");
        lastScore = PointsManager.totalGainedPoints;
        PointsManager.AddToScore(extraPoints);
    }
}
