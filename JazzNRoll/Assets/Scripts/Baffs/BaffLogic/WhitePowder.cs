using UnityEngine;

[CreateAssetMenu(fileName = "WhitePowder", menuName = "Baffs/WhitePowder")]
public class WhitePowder : Baff
{
    [SerializeField] ComboType[] combos;
    [SerializeField] float additiveKoef;
    public override void Start()
    {
        PointsManager.AddToComboModifiers(additiveKoef, combos);
    }
}

