using UnityEngine;

[CreateAssetMenu(fileName = "Hat", menuName = "Baffs/Hat")]
public class Hat : BaffByChance
{
    [SerializeField] float resultKoef;
    protected override void Activated()
    {
        Debug.Log("Hat Baff activated");
    }
    protected override void Deactivated()
    {
        Debug.Log("Hat Baff " + (PointsManager.totalGainedPoints - lastScore).ToString());
        //PointsManager.AddToScore((int)((PointsManager.totalGainedPoints - lastScore) * (resultKoef - 1)));//как нибудь показать что это очки от баффа
        BaffVisualization.ShowPointsByBaff(this.name, (int)((PointsManager.totalGainedPoints - lastScore) * (resultKoef - 1)));
    }
}