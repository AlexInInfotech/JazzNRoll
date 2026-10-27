using UnityEngine;

[CreateAssetMenu(fileName = "Newspaper", menuName = "Baffs/Newspaper")]
public class Newspaper : Baff
{
    [SerializeField] int extraChance;
    public override void Start()
    {
        BaffManager.AddToLegendaryChance(extraChance);
    }
}
