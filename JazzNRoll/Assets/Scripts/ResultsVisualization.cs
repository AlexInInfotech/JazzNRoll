using System.Collections;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using static DiceManager;
public class ResultsVisualization : MonoBehaviour
{
    [SerializeField] private Transform iconsContainer;
    [SerializeField] private Sprite[] _pointsSprites;
    [SerializeField] private TextMeshProUGUI _pointsUI;
    [SerializeField] private TextMeshProUGUI _pointsUI1;////

    [SerializeField] GameObject[] _comboObjects = new GameObject[2];
    //[SerializeField] Material[] _comboMaterials = new Material[2];

    [SerializeField] Texture[] _comboImages;
    [SerializeField] Transform valuesTextsContainer;
    private static MonoBehaviour staticScript;
    private static Sprite[] pointsSprites;
    private static TextMeshProUGUI pointsUI;
    private static TextMeshProUGUI pointsUI1;///

    static GameObject[] comboObjects;
    //static Material[] comboMaterials;
    static Texture[] comboImages;


    private static GameObject[] diceIcons;
    private static GameObject[] cubesValuesTexts;
    private static int _rolledDiceCount = 0;

    private static int currentResult = 0;
    void Start()
    {
        FallenDice.canvas = GetComponentInParent<Canvas>();
        //comboMaterials = _comboMaterials;
        comboObjects = _comboObjects;
        comboImages = _comboImages;
        staticScript = this;
        pointsSprites = _pointsSprites;
        pointsUI = _pointsUI;
        currentResult = 0;

        pointsUI1 = _pointsUI1; /////

        cubesValuesTexts = new GameObject[valuesTextsContainer.childCount];
        for (int i = 0; i < valuesTextsContainer.childCount; i++)
            cubesValuesTexts[i] = valuesTextsContainer.GetChild(i).gameObject;

        diceIcons = new GameObject[iconsContainer.childCount];
        for (int i = 0; i < iconsContainer.childCount; i++)
            diceIcons[i] = iconsContainer.GetChild(i).gameObject;
    }
    public static void ShowGainedPoints(int result)
    {
        staticScript.StartCoroutine(ShowResults(result));
    }
    static IEnumerator ShowResults(int result)
    {
        pointsUI.text = "+" + result;

        yield return new WaitForSeconds(2f);
        pointsUI.text = "";
        PointsManager.AddToScore(result);
    }

    public static void ShowCombo()
    {
        if (PointsManager.currentCombos[1] != ComboType.NoCombo)
        {
            comboObjects[1].SetActive(true);
            comboObjects[1].GetComponent<ParticleSystem>().Play();
            //comboObjects[1].GetComponent<Image>().sprite = comboImages[(int)PointsManager.currentCombos[1] - 1];
            comboObjects[1].GetComponent<ParticleSystemRenderer>().material.SetTexture("_MainTex", comboImages[(int)PointsManager.currentCombos[1] - 1]);
        }

        if (PointsManager.currentCombos[0] == ComboType.NoCombo)
            return;
        comboObjects[0].SetActive(true);
        //comboObjects[0].GetComponent<Image>().sprite = comboImages[(int)PointsManager.currentCombos[0] - 1];
        comboObjects[0].GetComponent<ParticleSystem>().Play();
        comboObjects[0].GetComponent<ParticleSystemRenderer>().material.SetTexture("_MainTex", comboImages[(int)PointsManager.currentCombos[0] - 1]);
    }

    public static void ShowAppearedDiceValue(FallenDice fallenDice)
    {
        diceIcons[_rolledDiceCount].GetComponent<Image>().sprite = pointsSprites[fallenDice.value];
        cubesValuesTexts[_rolledDiceCount].SetActive(true);
        cubesValuesTexts[_rolledDiceCount].GetComponent<TextMeshProUGUI>().text = fallenDice.value.ToString();
        cubesValuesTexts[_rolledDiceCount].GetComponent<RectTransform>().anchoredPosition = fallenDice.screenPosition;
        //cubesValuesTexts[_rolledDiceCount].GetComponent<RectTransform>().position = new Vector3(fallenDice.screenPosition.x, fallenDice.screenPosition.y,0) ;
        currentResult += fallenDice.value;

        UIAnimations.DrawTextToPoint(cubesValuesTexts[_rolledDiceCount].transform, pointsUI1.transform, 
            () => {  pointsUI1.gameObject.SetActive(true); pointsUI1.text = currentResult.ToString(); }
            , 3);
        



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
        pointsUI1.gameObject.SetActive(false);
        currentResult = 0;
        pointsUI1.text = "0";

    }
}
