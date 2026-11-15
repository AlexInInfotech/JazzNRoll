using UnityEngine;
[CreateAssetMenu(fileName = "CubanCigarette", menuName = "Baffs/CubanCigarette")]
public class CubanCigarette : BaffByChance
{
    [SerializeField] float additiveKoeff;

    protected override void Activated()
    {
        Debug.Log("CubanCigarette Baff");
        PointsManager.AddToComboModifiers(additiveKoeff);
        BaffVisualization.ShowBaffActivity(this.name, true);
    }
    protected override void Deactivated()
    {
        Debug.Log("CubanCigarette ddeBaff");
        PointsManager.AddToComboModifiers(-additiveKoeff);
        BaffVisualization.ShowBaffActivity(this.name, false);
    }
}
