using TMPro;
using UnityEngine;

public class DutyManager : MonoBehaviour
{
    [SerializeField] private int[] _duties;
    static int[] duties;
    static TextMeshProUGUI dutyUI;
    static byte dutyIndex = 0;
    const string DUTY = "Долг: ";

    public static int GetCurrentDuty()
    {
        return duties[dutyIndex];
    }
    private void ShowCurrentDuty()
    { 
        dutyUI.text = DUTY + duties[dutyIndex];
    }
    public void PayDuty()
    {
        if (PointsManager.GetScore() >= duties[dutyIndex])
        {
            PointsManager.AddToScore(-duties[dutyIndex]);
            dutyIndex++;
            if (dutyIndex < duties.Length)
            {

                ShowCurrentDuty();
                UIManager.StartTurn();
            }
            else
                GameEndManager.EndGame(true);

        }
        else
        {
            GameEndManager.EndGame(false);
        }
    }
    void Start()
    {
        duties = _duties;
        dutyUI = GetComponent<TextMeshProUGUI>();
        ShowCurrentDuty();
    }

   
}
