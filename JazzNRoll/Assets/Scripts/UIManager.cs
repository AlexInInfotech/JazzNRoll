
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _pointsUI;
    [SerializeField] private TextMeshProUGUI _countRollsUI;
    [SerializeField] private GameObject _rollButton;
    [SerializeField] private GameObject _speedButton;
    [SerializeField] private GameObject _betList;
    [SerializeField] private GameObject _baffList;
    [SerializeField] private GameObject _resultsRender;
    [SerializeField] private GameObject _dutyButton;
    [SerializeField] private TMP_Text _koeffsText;
    [SerializeField] private Scrollbar _pityBar;
    [SerializeField] private TMP_Text _debaffChance;

    private static TextMeshProUGUI countRollsUI;
    private static TextMeshProUGUI pointsUI;
    private static GameObject rollButton;
    private static GameObject speedButton;
    private static GameObject betList;
    private static GameObject baffList;
    private static GameObject resultsRender;
    private static GameObject dutyButton;
    private static TMP_Text koeffsText;
    private static Scrollbar pityBar;
    private static TMP_Text debaffChance;
    static string pointsText = "Очки: ";
    static string rollsText = "Броски: ";
    static string debaffText = "Шанс дебаффа: ";
    static string[] pointTexts = { "Очки: ", "Score: " };
    static string[] rollsTexts = { "Броски: ", "Rolls: " };
    static string[] debaffTexts = { "Шанс дебаффа: ", "Debaff chance: " };
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
        pityBar.value = (float)(BaffManager.pityPoints + BaffManager.maxPity) / (2*BaffManager.maxPity);
    }
    public static void BetMade()
    {
        rollButton.SetActive(true);
        resultsRender.SetActive(true);
        speedButton.SetActive(true);


        dutyButton.SetActive(false);
        betList.SetActive(false);
        baffList.SetActive(false);
    }
    public static void ShowDebaffChance(int value)
    {
        debaffChance.text = debaffText + value.ToString() + "%";
    }
    public static void RollsFinish()
    {
        baffList.SetActive(true);



        speedButton.SetActive(false);
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
        speedButton.SetActive(false);

    }
    public static void StartTurn()
    {
        betList.SetActive(true);


        speedButton.SetActive(false);
        dutyButton.SetActive(false);
        baffList.SetActive(false);
        rollButton.SetActive(false);
        resultsRender.SetActive(false);
    }
    public static void languageChanged()
    {
        pointsText = pointTexts[(int)LanguageManager.language];
        PrintScore(PointsManager.GetScore().ToString());
        rollsText = rollsTexts[(int)LanguageManager.language];
        PrintRemainingRolls(DiceManager.remainingRolls.ToString());
        debaffText = debaffTexts[(int)LanguageManager.language];
        ShowDebaffChance(0);

    }
    private void Awake()
    {
        debaffChance = _debaffChance;
        speedButton = _speedButton;
        dutyButton = _dutyButton;
        pointsUI = _pointsUI;
        countRollsUI = _countRollsUI;
        rollButton = _rollButton;
        betList = _betList;
        baffList = _baffList;
        resultsRender= _resultsRender;
        koeffsText = _koeffsText;
        pityBar = _pityBar;
        languageChanged();
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
