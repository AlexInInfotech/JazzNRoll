
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DiceManager;
public class ResultsVisualization : MonoBehaviour
{
    [SerializeField] private Transform iconsContainer;
    [SerializeField] Transform valuesTextsContainer;
    [SerializeField] private TextMeshProUGUI _pointsUI;////
    [SerializeField] RectTransform _score;
    [SerializeField] GameObject[] _comboObjects = new GameObject[2];
    [SerializeField] private Sprite[] _pointsSprites;
    [SerializeField] Sprite[] _comboImages;
    //[SerializeField] Material[] _comboMaterials = new Material[2];
    [SerializeField] float _countingDelay = 1;
    [SerializeField] float _drawingAnimationTime = 1;

    public static bool isFinished { get; private set; } = true;
    static float countingDelay;
    static float drawingAnimationTime;
    private static Sprite[] pointsSprites;
    private static TextMeshProUGUI pointsUI;

    static GameObject[] comboObjects;
    static Sprite[] comboImages;
    static RectTransform score;


    private static GameObject[] diceIcons;
    private static GameObject[] cubesValuesTexts;
    private static int _rolledDiceCount = 0;
    private static Vector3 pointsStartPosition = new Vector3();
    //private static int currentResult { get; private set; } = 0;
    private static int currentResult= 0;
    void Start()
    {
        score = _score;
        //comboMaterials = _comboMaterials;
        comboObjects = _comboObjects;
        comboImages = _comboImages;
        countingDelay = _countingDelay;
        drawingAnimationTime = _drawingAnimationTime;
        pointsSprites = _pointsSprites;
        currentResult = 0;

        pointsUI = _pointsUI; /////
        pointsStartPosition = pointsUI.transform.localPosition;

        cubesValuesTexts = new GameObject[valuesTextsContainer.childCount];
        for (int i = 0; i < valuesTextsContainer.childCount; i++)
            cubesValuesTexts[i] = valuesTextsContainer.GetChild(i).gameObject;

        diceIcons = new GameObject[iconsContainer.childCount];
        for (int i = 0; i < iconsContainer.childCount; i++)
            diceIcons[i] = iconsContainer.GetChild(i).gameObject;
    }
    //public static void ShowGainedPoints(int result)
    //{
    //    staticScript.StartCoroutine(ShowResults(result));
    //}
    //static IEnumerator ShowResults(int result)
    //{
    //    pointsUI2.text = "+" + result;

    //    yield return new WaitForSeconds(2f);
    //    pointsUI2.text = "";
    //    PointsManager.AddToScore(result);
    //}

    public static void ShowCombo()
    {
        if (PointsManager.currentCombos[1] != ComboType.NoCombo)
        {
            comboObjects[1].SetActive(true);
            comboObjects[1].GetComponent<ParticleSystem>().Play();
            comboObjects[1].GetComponent<Image>().sprite = comboImages[(int)PointsManager.currentCombos[1] - 1];
            //comboObjects[1].GetComponent<ParticleSystemRenderer>().material.SetTexture("_MainTex", comboImages[(int)PointsManager.currentCombos[1] - 1]);
        }

        if (PointsManager.currentCombos[0] == ComboType.NoCombo)
            return;
        comboObjects[0].SetActive(true);
        comboObjects[0].GetComponent<Image>().sprite = comboImages[(int)PointsManager.currentCombos[0] - 1];
        comboObjects[0].GetComponent<ParticleSystem>().Play();
        //comboObjects[0].GetComponent<ParticleSystemRenderer>().material.SetTexture("_MainTex", comboImages[(int)PointsManager.currentCombos[0] - 1]);
    }
    private static void ShowCounting()
    {
        string[] texts= new string[2];
        if (PointsManager.currentCombos[0] != ComboType.NoCombo && PointsManager.currentCombos[1] != ComboType.NoCombo)
            texts[0] = currentResult.ToString()
                + " X " + PointsManager.ComboModifiers[PointsManager.currentCombos[0]]
                + " X " + PointsManager.ComboModifiers[PointsManager.currentCombos[1]];
        else if (PointsManager.currentCombos[0] != ComboType.NoCombo)
            texts[0] = currentResult.ToString() + " X " + PointsManager.ComboModifiers[PointsManager.currentCombos[0]];
        else
            texts[0] = currentResult.ToString() + " X " + PointsManager.ComboModifiers[PointsManager.currentCombos[1]];
        currentResult = (int)(PointsManager.ComboModifiers[PointsManager.currentCombos[1]] * PointsManager.ComboModifiers[PointsManager.currentCombos[0]]* currentResult);
        texts[1] = currentResult.ToString();
        UIAnimations.TextChanging(pointsUI, texts, countingDelay, () => {  UIAnimations.DrawTextToPoint(pointsUI.transform, score, () => { isFinished = true; PointsManager.AddToScore(currentResult); }); });
        
    }
    private static byte finishedAnimations = 0;
    public static void ShowAppearedDiceValue(FallenDice fallenDice)
    {
        isFinished = false;
        diceIcons[_rolledDiceCount].GetComponent<Image>().sprite = pointsSprites[fallenDice.value];
        cubesValuesTexts[_rolledDiceCount].SetActive(true);
        cubesValuesTexts[_rolledDiceCount].GetComponent<TextMeshProUGUI>().text = fallenDice.value.ToString();
        cubesValuesTexts[_rolledDiceCount].GetComponent<RectTransform>().anchoredPosition = fallenDice.screenPosition;
        //cubesValuesTexts[_rolledDiceCount].GetComponent<RectTransform>().position = new Vector3(fallenDice.screenPosition.x, fallenDice.screenPosition.y,0) ;
        //currentResult += fallenDice.value;

        UIAnimations.DrawTextToPoint(cubesValuesTexts[_rolledDiceCount].transform, pointsUI.transform, 
            () => {  pointsUI.gameObject.SetActive(true);
                currentResult += fallenDice.value;
                pointsUI.text = currentResult.ToString();
                finishedAnimations++;
                if (finishedAnimations == DiceManager.diceCount)
                    ShowCounting();

            }
            , drawingAnimationTime);
        



        _rolledDiceCount++;
        if (_rolledDiceCount == diceCount)
            _rolledDiceCount = 0;



        //    for (int i = 0; i < diceIcons.Length; i++)
        //        diceIcons[i].GetComponent<Image>().sprite = pointsSprites[0];

    }


    public static void ClearResults()
    {
        for (int i = 0; i < diceIcons.Length; i++)
        {
            cubesValuesTexts[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
            //cubesValuesTexts[i].SetActive(false);
            diceIcons[i].GetComponent<Image>().sprite = pointsSprites[0];
        }
        comboObjects[0].SetActive(false);
        comboObjects[1].SetActive(false);
        pointsUI.gameObject.SetActive(false);
        pointsUI.transform.localPosition = pointsStartPosition;
        currentResult = 0;
        finishedAnimations = 0;
        pointsUI.text = "0";

    }
}
