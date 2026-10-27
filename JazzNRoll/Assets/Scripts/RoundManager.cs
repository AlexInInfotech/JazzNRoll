using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    static TextMeshProUGUI roundCounter;
    static byte totalRounds = 3;
    static byte currentRound =0;
    public static bool IsLastRound()
    {
        return currentRound == totalRounds;
    }
    private void Start()
    {
        roundCounter = GetComponent<TextMeshProUGUI>();
        NextRound();
    }
    public static void NextRound()
    {
        currentRound++;
        if (currentRound > totalRounds)
            FinishRound();
        else
            UIManager.StartTurn();
        roundCounter.text = currentRound.ToString() + "/" + totalRounds.ToString();

    }
    private static void FinishRound()
    {
        currentRound = 1;
        UIManager.DutyTime();
    }
}
