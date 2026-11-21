using TMPro;
using UnityEngine;
using System;

public class DutyManager : MonoBehaviour
{
    [SerializeField] private int[] _duties;
    static int[] duties;
    static TextMeshProUGUI dutyUI;
    static byte dutyIndex = 0;
    static string dutyText = "Долг: ";
    static string[] dutyTexts = { "Долг: ", "Duty: " };

    public static int GetCurrentDuty()
    {
        return duties[dutyIndex];
    }
    private void ShowCurrentDuty()
    { 
        dutyUI.text = dutyText + duties[dutyIndex];
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
        LanguageManager.languageChanged += OnLanguageChanged;
        duties = _duties;
        dutyUI = GetComponent<TextMeshProUGUI>();
        OnLanguageChanged();
    }
    private void OnLanguageChanged()
    {
        dutyText = dutyTexts[(int)LanguageManager.language];
        ShowCurrentDuty();

    }
   
}
