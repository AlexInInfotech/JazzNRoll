using UnityEngine;

public enum Rarity
{
    usual = 0, rare, legendary, debaff
}

[CreateAssetMenu(fileName = "NewBaffItem", menuName = "Configs/Baff Item")]
public class BaffItem : Item
{
    public Baff baff;
    public override void Start()
    {
        baff.Start();
    }
}
