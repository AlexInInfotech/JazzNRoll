using UnityEngine;

[CreateAssetMenu(fileName = "Pass", menuName = "Baffs/Pass")]
public class Pass : Baff
{
    [SerializeField] int deltaCombo;
    [SerializeField] byte extraRolls;
    int comboCounter = 0;
    public override void ModifyGame()
    {
        foreach(ComboType combo in PointsManager.currentCombos)
            if (combo!= ComboType.NoCombo)
                comboCounter++;
        if (comboCounter >= deltaCombo)
        {
            //DiceManager.AddRolls(extraRolls);

            BaffVisualization.AddRollsByBaff(this.name, extraRolls);
            comboCounter = 0;
        }

    }
}