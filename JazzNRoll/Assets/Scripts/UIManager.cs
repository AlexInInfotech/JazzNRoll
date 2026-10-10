using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _pointsUI;
    [SerializeField] private TextMeshProUGUI _countRollsUI;

    private static TextMeshProUGUI countRollsUI;
    private static TextMeshProUGUI pointsUI;
    private const string pointsText = "Очки: ";
    private const string rollsText = "Броски: ";
    private void Start()
    {
        pointsUI = _pointsUI;
        countRollsUI = _countRollsUI;
    }
    public static void PrintPoints(string value)
    {
        pointsUI.text = pointsText + value;
    }
    public static void PrintRolls(string value)
    {
        countRollsUI.text = rollsText + value;
    }
}
