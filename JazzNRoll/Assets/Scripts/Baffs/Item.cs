using UnityEngine;

public class Item : ScriptableObject
{
    public Sprite icon;
    public string[] titles;
    public string[] descriptions;
    public Rarity rarity;
    public virtual void Start()
    {
        return;
    }
}
