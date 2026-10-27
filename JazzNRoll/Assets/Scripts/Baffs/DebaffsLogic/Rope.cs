using UnityEngine;
[CreateAssetMenu(fileName = "Rope", menuName = "Debaffs/Rope")]
public class Rope : Baff
{
    [SerializeField] int newChance;
    [SerializeField] int newAdditiveChance;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
}
