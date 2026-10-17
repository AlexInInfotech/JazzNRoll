using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _pointsUI;
    [SerializeField] private TextMeshProUGUI _countRollsUI;
    [SerializeField] private GameObject _rollButton;
    [SerializeField] private GameObject _betList;
    [SerializeField] private GameObject _baffList;

    private static TextMeshProUGUI countRollsUI;
    private static TextMeshProUGUI pointsUI;
    private static GameObject rollButton;
    private static GameObject betList;
    private static GameObject baffList;
    private const string pointsText = "Очки: ";
    private const string rollsText = "Броски: ";
    public static void BetMade()
    {
        betList.SetActive(false);
        baffList.SetActive(false);
        rollButton.SetActive(true);
    }
    public static void FinishRound()
    {
        baffList.SetActive(true);
        betList.SetActive(false);
        rollButton.SetActive(false);
    }
    public static void BaffPicked()
    {
        baffList.SetActive(false);
        betList.SetActive(true);
        rollButton.SetActive(false);
    }
    private void Start()
    {
        pointsUI = _pointsUI;
        countRollsUI = _countRollsUI;
        rollButton = _rollButton;
        betList = _betList;
        baffList = _baffList;
        betList.SetActive(true);
        rollButton.SetActive(false);
        baffList.SetActive(false);
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
