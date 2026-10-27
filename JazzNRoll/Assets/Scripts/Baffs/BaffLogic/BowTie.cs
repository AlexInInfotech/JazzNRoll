using UnityEngine;


[CreateAssetMenu(fileName = "BowTie", menuName = "Baffs/BowTie")]
public class BowTie : Baff
{
    [SerializeField] int workChance;
    [SerializeField] int additivePoints;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)//начало броска
            return;
        if (Random.Range(0, 100) < workChance)
        {
            Debug.Log("BowTie activated");//как нибудь показать что бафф активировался
            PointsManager.AddToScore(additivePoints);
        }

        lastScore = PointsManager.totalGainedPoints;
    }
}