using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Diagnostics;

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
            ShowCurrentDuty();
            UIManager.StartTurn();
        }
        else
        {
            Debug.Log("LOSe");
        }
    }
    void Start()
    {
        duties = _duties;
        dutyUI = GetComponent<TextMeshProUGUI>();
        ShowCurrentDuty();
    }

   
}
