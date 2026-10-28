using UnityEngine;

[CreateAssetMenu(fileName = "Razor", menuName = "Debaffs/Razor")]
public class Razor : Baff
{
    [SerializeField] int deltaScore;
    [SerializeField] float deductedKoeff;
    int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints - lastScore < deltaScore)
            return;
        Debug.Log("Razor");
        lastScore = PointsManager.totalGainedPoints;
        PointsManager.AddToComboModifiers(-deductedKoeff);
    }
}
