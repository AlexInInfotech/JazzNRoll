using UnityEngine;

[CreateAssetMenu(fileName = "JazzRecord", menuName = "Baffs/JazzRecord")]
public class JazzRecord : Baff
{
    [SerializeField] int extraRolls;
    bool IsActivated = false;
    public override void Start()
    {
        ModifyGame();
    }
    public override void ModifyGame()
    {
        if (IsActivated && !RoundManager.IsLastRound())
            IsActivated = false;
        if (!IsActivated && RoundManager.IsLastRound() && DiceManager.remainingRolls == 0 && DutyManager.GetCurrentDuty() >= PointsManager.GetScore())
        {
            Debug.Log("JAZZ");
            DiceManager.AddRolls(extraRolls);
            IsActivated = true;
        }
    }
}

