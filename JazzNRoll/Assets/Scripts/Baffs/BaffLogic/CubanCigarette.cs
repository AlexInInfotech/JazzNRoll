using UnityEngine;
[CreateAssetMenu(fileName = "CubanCigarette", menuName = "Baffs/CubanCigarette")]
public class CubanCigarette : BaffByChance
{
    [SerializeField] float additiveKoeff;

    protected override void Activated()
    {
        PointsManager.AddToComboModifiers(additiveKoeff);
        BaffVisualization.ShowBaffActivity(this.name, true);
    }
    protected override void Deactivated()
    {
        PointsManager.AddToComboModifiers(-additiveKoeff);
        BaffVisualization.ShowBaffActivity(this.name, false);
    }
}
