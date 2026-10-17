using UnityEngine;

[CreateAssetMenu(fileName = "NewBaffItem", menuName = "Configs/Baff Item")]
public class BaffItem : ScriptableObject
{
    public Baff baff;
    public Sprite icon;
    public Sprite cardSprite;
    public string title;
    public string description;
}
