using UnityEngine;

[CreateAssetMenu(fileName = "Aces", menuName = "Baffs/Aces")]
public class Aces : Baff
{
    [SerializeField] byte[] conditionNumbers;
    [SerializeField] int deltaScore;
    [SerializeField] byte extraRolls;
    int gainedConditionPoints = 0;
    int lastScore;
    public override void Start()
    {
        gainedConditionPoints = 0;
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints ==lastScore)
            return;
        if (IsNumsInDropped())
        {
            gainedConditionPoints += PointsManager.totalGainedPoints - lastScore;
            Debug.Log("IS NUMS IN dropped");

        }
        if (gainedConditionPoints >= deltaScore)
        {
            Debug.Log("Aces");
            //DiceManager.AddRolls(extraRolls);
            BaffVisualization.AddRollsByBaff(this.name, extraRolls);
            gainedConditionPoints = 0;
        }
        lastScore = PointsManager.totalGainedPoints;

    }
    private bool IsNumsInDropped()
    {
        byte count = 0;
        foreach (byte num in conditionNumbers)
            count += PointsManager.CountNumInDropped(num);
        return count > 0;
    }
}