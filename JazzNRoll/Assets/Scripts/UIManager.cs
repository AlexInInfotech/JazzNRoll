
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _pointsUI;
    [SerializeField] private TextMeshProUGUI _countRollsUI;
    [SerializeField] private GameObject _rollButton;
    [SerializeField] private GameObject _betList;
    [SerializeField] private GameObject _baffList;
    [SerializeField] private GameObject _resultsRender;
    [SerializeField] private GameObject _dutyButton;
    [SerializeField] private TMP_Text _koeffsText;
    [SerializeField] private Scrollbar _pityBar;

    private static TextMeshProUGUI countRollsUI;
    private static TextMeshProUGUI pointsUI;
    private static GameObject rollButton;
    private static GameObject betList;
    private static GameObject baffList;
    private static GameObject resultsRender;
    private static GameObject dutyButton;
    private static TMP_Text koeffsText;
    private static Scrollbar pityBar;
    private const string pointsText = "Очки: ";
    private const string rollsText = "Броски: ";
    public static void UpdateKoefsVisualization()
    {
        string s = "";
        ComboType[] types = (ComboType[])System.Enum.GetValues(typeof(ComboType));
        for (int i = 0; i < types.Length; i++)
            if (types[i] != ComboType.NoCombo)
                s += PointsManager.ComboModifiers[types[i]].ToString()+"\n";
        koeffsText.text = s;
    }
    public static void ShowPity()
    {
        Debug.Log((float)(BaffManager.pityPoints + BaffManager.maxPity) / (2 * BaffManager.maxPity));
        pityBar.value = (float)(BaffManager.pityPoints + BaffManager.maxPity) / (2*BaffManager.maxPity);
    }
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
        koeffsText = _koeffsText;
        pityBar = _pityBar;
        ShowPity();
        UpdateKoefsVisualization();
        StartTurn();
    }
    public static void PrintScore(string value)
    {
        pointsUI.text = pointsText + value;
    }
    public static void PrintRemainingRolls(string value)
    {
        countRollsUI.text = rollsText + value;
    }
}
