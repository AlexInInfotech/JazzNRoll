using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class DutyManager : MonoBehaviour
{
    [SerializeField] private int[] duties;
    static TextMeshProUGUI dutyUI;
    byte dutyIndex = 0;
    string DUTY = "Долг: ";
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
        dutyUI = GetComponent<TextMeshProUGUI>();
        ShowCurrentDuty();
    }

   
}
