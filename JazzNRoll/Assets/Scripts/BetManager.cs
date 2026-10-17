using UnityEngine;

public class BetManager : MonoBehaviour
{

    public static bool betIsMade = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetBet(int bet)
    {
        PointsManager.AddToPoints(-bet);
        DiceManager.ChangeAvailableRolls(bet / 25);
        UIManager.BetMade();
        CameraAnimationController.BetMade();
    }
}
