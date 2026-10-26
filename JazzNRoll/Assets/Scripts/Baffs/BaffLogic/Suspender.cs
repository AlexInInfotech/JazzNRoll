using UnityEngine;
[CreateAssetMenu(fileName = "Suspender", menuName = "Baffs/Suspender")]
public class Suspender : Baff
{
    [SerializeField] byte[] conditionNumbers;
    [SerializeField] byte additiveProcent;
    int gainedConditionPoints = 0;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)
            return;
        if (IsNumsInDropped())
        {
            gainedConditionPoints += PointsManager.totalGainedPoints - lastScore;
            if (gainedConditionPoints %2 == 0)
            {
                Debug.Log("Suspender");
                PointsManager.AddToScore((int)Mathf.Ceil((float)(gainedConditionPoints * (100 + additiveProcent) / 100)));
            }

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
