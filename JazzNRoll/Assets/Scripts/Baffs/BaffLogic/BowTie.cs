using UnityEngine;


[CreateAssetMenu(fileName = "BowTie", menuName = "Baffs/BowTie")]
public class BowTie : BaffByChance
{
    [SerializeField] int additivePoints;

    protected override void Activated()
    {
        Debug.Log("BowTie activated");//как нибудь показать что бафф активировался
        //PointsManager.AddToScore(additivePoints);
        BaffVisualization.ShowPointsByBaff(this.name, additivePoints);

    }
}