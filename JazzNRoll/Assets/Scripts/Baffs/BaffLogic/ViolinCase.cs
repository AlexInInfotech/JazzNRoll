using UnityEngine;

[CreateAssetMenu(fileName = "ViolinCase", menuName = "Baffs/ViolinCase")]
public class ViolinCase : Baff
{
    [SerializeField] int deltaScore;
    [SerializeField] float additiveKoeff;
    int lastScore;
    bool Activate = false;
    public override void Start()
    {
        Activate = false;
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        Debug.Log("ViolinCas  " + Activate);
        if (Activate && PointsManager.totalGainedPoints - lastScore!= 0)//модификации активируются перед броском и после, а эффект должен продержаться один бросок
        {
            Debug.Log("ViolinCase DEBaff");
            Activate = false;
            PointsManager.AddToComboModifiers(-additiveKoeff);
        }
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("ViolinCase Baff");
        PointsManager.AddToComboModifiers(additiveKoeff); 
        lastScore = PointsManager.totalGainedPoints;
        Activate = true;

    }
    
}
