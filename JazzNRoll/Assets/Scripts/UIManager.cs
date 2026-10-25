using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _pointsUI;
    [SerializeField] private TextMeshProUGUI _countRollsUI;
    [SerializeField] private GameObject _rollButton;
    [SerializeField] private GameObject _betList;
    [SerializeField] private GameObject _baffList;
    [SerializeField] private GameObject _resultsRender;
    [SerializeField] private GameObject _dutyButton;

    private static TextMeshProUGUI countRollsUI;
    private static TextMeshProUGUI pointsUI;
    private static GameObject rollButton;
    private static GameObject betList;
    private static GameObject baffList;
    private static GameObject resultsRender;
    private static GameObject dutyButton;
    private const string pointsText = "Очки: ";
    private const string rollsText = "Броски: ";
    public static void BetMade()
    {
        rollButton.SetActive(true);
        resultsRender.SetActive(true);

        dutyButton.SetActive(false);

        betList.SetActive(false);
        baffList.SetActive(false);
    }
    public static void RollsFinish()
    {
        baffList.SetActive(true);


        dutyButton.SetActive(false);
        betList.SetActive(false);
        rollButton.SetActive(false);
        resultsRender.SetActive(false);
    }
    public static void DutyTime()
    {
        dutyButton.SetActive(true);


        baffList.SetActive(false);
        betList.SetActive(false);
        rollButton.SetActive(false);
        resultsRender.SetActive(false);
    }
    public static void StartTurn()
    {
        betList.SetActive(true);

        dutyButton.SetActive(false);

        baffList.SetActive(false);
        rollButton.SetActive(false);
        resultsRender.SetActive(false);
    }
    private void Awake()
    {
        dutyButton = _dutyButton;
        pointsUI = _pointsUI;
        countRollsUI = _countRollsUI;
        rollButton = _rollButton;
        betList = _betList;
        baffList = _baffList;
        resultsRender= _resultsRender;
        StartTurn();
    }
    public static void PrintPoints(string value)
    {
        pointsUI.text = pointsText + value;
    }
    public static void PrintRemainingRolls(string value)
    {
        countRollsUI.text = rollsText + value;
    }
}
