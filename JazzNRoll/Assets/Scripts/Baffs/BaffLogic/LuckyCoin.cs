using UnityEngine;

[CreateAssetMenu(fileName = "LuckyCoin", menuName = "Baffs/LuckyCoin")]
public class LuckyCoin : Baff
{
    [SerializeField] byte conditionNum;
    [SerializeField] byte countNum;
    [SerializeField] float additiveKoef;
    public override void ModifyGame()
    {
        if (PointsManager.CountNumInDropped(conditionNum) >= countNum)
            PointsManager.AddToComboModifiers(additiveKoef);

    }
}
