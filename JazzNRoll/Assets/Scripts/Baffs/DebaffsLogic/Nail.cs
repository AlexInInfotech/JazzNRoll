using UnityEngine;

[CreateAssetMenu(fileName = "Nail", menuName = "Debaffs/Nail")]
public class Nail : BaffByChance
{
    [SerializeField] float deductedKoef;
    protected override void Activated()
    {
        Debug.Log("Nail activated");
        PointsManager.AddToComboModifiers(-deductedKoef);
    }
}
