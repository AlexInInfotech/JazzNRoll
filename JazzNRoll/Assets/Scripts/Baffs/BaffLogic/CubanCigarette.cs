using UnityEngine;
[CreateAssetMenu(fileName = "CubanCigarette", menuName = "Baffs/CubanCigarette")]
public class CubanCigarette : Baff
{
    [SerializeField] int workChance;
    [SerializeField] int extraKoeff;
    int lastScore;
    bool active =false;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)//начало броска
            if (Random.Range(0, 100) < workChance)
            {
                Debug.Log("CubanCigarette Baff");
                PointsManager.AddToComboModifiers(extraKoeff);
                active = true;
            }
        if (PointsManager.totalGainedPoints != lastScore)//после броска
        {
            lastScore = PointsManager.totalGainedPoints;
            if (active)
            {
                Debug.Log("CubanCigarette ddeBaff");
                PointsManager.AddToComboModifiers(-extraKoeff);
                active = false;
            }
        }

    }
}
