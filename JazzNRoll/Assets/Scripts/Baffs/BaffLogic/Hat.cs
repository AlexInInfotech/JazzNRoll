using UnityEngine;

[CreateAssetMenu(fileName = "Hat", menuName = "Baffs/Hat")]
public class Hat : Baff
{
    [SerializeField] int workChance;
    [SerializeField] float resultKoef;
    int lastScore;
    bool active = false;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)//начало броска
            if (Random.Range(0, 100) < workChance)
            {
                Debug.Log("Hat Baff activated");//как нибудь показать что бафф активировался
                active = true;
            }
        if (PointsManager.totalGainedPoints != lastScore)//после броска
        {
            if (active)
            {
                Debug.Log("Hat Baff " + (PointsManager.totalGainedPoints - lastScore).ToString());
                PointsManager.AddToScore((int)((PointsManager.totalGainedPoints - lastScore) * (resultKoef - 1)));//как нибудь показать что это очки от баффа
                active = false;
            }
            lastScore = PointsManager.totalGainedPoints;
        }

    }
}