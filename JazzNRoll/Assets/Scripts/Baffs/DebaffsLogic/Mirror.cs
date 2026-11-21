using UnityEngine;

[CreateAssetMenu(fileName = "Mirror", menuName = "Baffs/Mirror")]
public class Mirror : Baff
{
    [SerializeField] ComboType[] combos;
    [SerializeField] float deductedKoef;
    public override void Start()
    {
        PointsManager.AddToComboModifiers(-deductedKoef, combos);
    }
}

