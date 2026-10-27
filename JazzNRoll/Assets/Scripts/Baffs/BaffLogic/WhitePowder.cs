using UnityEngine;

[CreateAssetMenu(fileName = "WhitePowder", menuName = "Baffs/WhitePowder")]
public class WhitePowder : Baff
{
    [SerializeField] ComboType[] combos;
    [SerializeField] float additiveKoef;
    public override void Start()
    {
        Debug.Log("WhitePowder");
        PointsManager.AddToComboModifiers(additiveKoef, combos);
    }
}

