using UnityEngine;

[CreateAssetMenu(fileName = "Pearls", menuName = "Baffs/Pearls")]
public class Pearls : Baff
{
    [SerializeField] ComboType[] conditionalTypes;
    [SerializeField] float koef;
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
        PointsManager.AddToScore((int)(gainedConditionPoints* koef));
        if (IsComboDropped())
            gainedConditionPoints += PointsManager.totalGainedPoints - lastScore;
        lastScore = PointsManager.totalGainedPoints;

    }
    private bool IsComboDropped()
    {
        foreach (ComboType combo in conditionalTypes)
            if (PointsManager.currentCombos[0] == combo || PointsManager.currentCombos[1] == combo)
                return true;
        return false;
    }
}
