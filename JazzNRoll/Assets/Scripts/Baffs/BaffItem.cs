using UnityEngine;

public enum Rarity
{
    usual = 0, rare, legendary, debaff
}

[CreateAssetMenu(fileName = "NewBaffItem", menuName = "Configs/Baff Item")]
public class BaffItem : ScriptableObject
{
    public Baff baff;
    public Sprite icon;
    public string title;
    public string description;
    public Rarity rarity;
}
