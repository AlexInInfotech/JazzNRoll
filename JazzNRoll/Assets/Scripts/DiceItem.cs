using UnityEngine;
[CreateAssetMenu(fileName = "NewDiceItem", menuName = "Configs/DiceItem")]
public class DiceItem : Item
{
    public DiceInfo dice;
    public override void Start()
    {
        Debug.Log("Pick Dice " + dice.name);
        DiceManager.ChangeDice(dice);
    }
}
