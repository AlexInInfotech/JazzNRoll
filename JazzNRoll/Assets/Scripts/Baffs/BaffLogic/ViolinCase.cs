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
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (Activate && PointsManager.totalGainedPoints - lastScore!= 0)//модификации активируются перед броском и после, а эффект должен продержаться один бросок
        {
            Activate = false;
            PointsManager.AddToComboModifiers(-extraKoeff);
        }
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("ViolinCase Baff");
        PointsManager.AddToComboModifiers(extraKoeff); 
        lastScore = PointsManager.totalGainedPoints;
        Activate = true;

    }
    
}
