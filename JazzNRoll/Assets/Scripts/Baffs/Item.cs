using UnityEngine;

public class Item : ScriptableObject
{
    public Sprite icon;
    public string title;
    public string description;
    public Rarity rarity;
    public virtual void Start()
    {
        return;
    }
}
