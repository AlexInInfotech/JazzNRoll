using UnityEngine;
[CreateAssetMenu(fileName = "Poker", menuName = "Baffs/Poker")]
public class Poker : Baff
{
    [SerializeField] int deltaScore;
    [SerializeField] int extraPoints;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.gainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.gainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("Poker");
        lastScore = PointsManager.gainedPoints;
        PointsManager.AddToPoints(extraPoints);
    }
}
