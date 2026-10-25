using UnityEngine;

[CreateAssetMenu(fileName = "NewBet", menuName = "Bet")]
public class Bet : ScriptableObject
{
    public int cost;
    public byte rollsCount;
    public int pityPoints; 
}
