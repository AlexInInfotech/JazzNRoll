using UnityEngine;

public class BetManager : MonoBehaviour
{

    public static bool betIsMade = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetBet(Bet bet)
    {
        PointsManager.AddToPoints(-bet.cost);
        DiceManager.ChangeAvailableRolls(bet.rollsCount);
        BaffManager.pityPoints += bet.pityPoints;
        UIManager.BetMade();
        CameraAnimationController.BetMade();
    }
}
