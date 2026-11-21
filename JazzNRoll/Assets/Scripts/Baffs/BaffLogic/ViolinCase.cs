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
        if (Activate && PointsManager.totalGainedPoints - lastScore!= 0)//модификации активируются перед броском и после, а эффект должен продержаться один бросок
        {
            Activate = false;
            PointsManager.AddToComboModifiers(-additiveKoeff);
            BaffVisualization.ShowBaffActivity(this.name, false);
        }
        BaffVisualization.ShowBaffScore(this.name, PointsManager.totalGainedPoints - lastScore);
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        PointsManager.AddToComboModifiers(additiveKoeff);
        BaffVisualization.ShowBaffActivity(this.name, true);
        lastScore = PointsManager.totalGainedPoints;
        Activate = true;

    }
    
}
