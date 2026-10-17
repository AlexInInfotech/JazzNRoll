using UnityEngine;
[CreateAssetMenu(fileName = "Poker", menuName = "Baffs/Poker")]
public class Poker : Baff
{
    int unit = 10;
    public override void ModifyGame()
    {
        Debug.Log("Poker" + unit);
    }
}
