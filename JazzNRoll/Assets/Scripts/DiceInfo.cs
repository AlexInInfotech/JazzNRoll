using UnityEngine;
[CreateAssetMenu(fileName = "DiceInfo", menuName = "Dice/DiceInfo")]
public class DiceInfo : ScriptableObject
{
    public  byte[] valueOnFaces = new byte[6];
    public Material material;
}
