using UnityEngine;
[CreateAssetMenu(fileName = "RopeOrBit", menuName = "Debaffs/RopeOrBit")]
public class Rope : Baff
{
    [SerializeField] int newChance;
    [SerializeField] int newAdditiveChance;
    [SerializeField] BaffByChance[] baffByChances;
    public override void Start()
    {
        foreach (BaffByChance baff in baffByChances)
        {
            baff.workChance = newChance;
            baff.additiveChance = newAdditiveChance;
        }
    }
}
