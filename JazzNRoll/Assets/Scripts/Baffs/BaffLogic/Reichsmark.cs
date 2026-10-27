using UnityEngine;

[CreateAssetMenu(fileName = "Reichsmark", menuName = "Baffs/Reichsmark")]
public class Reichsmark : Baff
{
    [SerializeField] ComboType[] combo;
    [SerializeField] float additiveKoef;
    public override void Start()
    {
        PointsManager.AddToComboModifiers(additiveKoef, combo);
    }
}
