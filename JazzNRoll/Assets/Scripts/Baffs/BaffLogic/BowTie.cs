using UnityEngine;


[CreateAssetMenu(fileName = "BowTie", menuName = "Baffs/BowTie")]
public class BowTie : BaffByChance
{
    [SerializeField] int additivePoints;

    protected override void Activated()
    {
        BaffVisualization.AddPointsByBaff(this.name, additivePoints);

    }
}