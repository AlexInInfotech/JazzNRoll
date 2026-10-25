using UnityEngine;

[CreateAssetMenu(fileName = "ViolinCase", menuName = "Baffs/ViolinCase")]
public class ViolinCase : Baff
{
    [SerializeField] int deltaScore;
    [SerializeField] float extraKoeff;
    int lastScore;
    bool Activate = false;
    public override void Start()
    {
        lastScore = PointsManager.gainedPoints;
    }
    public override void ModifyGame()
    {
        if (Activate && PointsManager.gainedPoints - lastScore!= 0)//модификации активируются перед броском и после, а эффект должен продержаться один бросок
        {
            Activate = false;
            ChangeComboKoef(-extraKoeff);
        }
        if (PointsManager.gainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("ViolinCase Baff");
        ChangeComboKoef(extraKoeff);
        lastScore = PointsManager.gainedPoints;
        Activate = true;

    }
    private void ChangeComboKoef(float value)
    {
        ComboType[] comboKeys = (ComboType[])System.Enum.GetValues(typeof(ComboType));
        for (int i = 0; i < comboKeys.Length; i++)
            PointsManager.ComboModifiers[comboKeys[i]] += value;
    }
}
