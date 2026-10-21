using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using NUnit.Framework.Constraints;
public class ResultsVisualiisation : MonoBehaviour
{
    private static GameObject[] diceIcons;
    [SerializeField] private Transform iconsContainer;
    [SerializeField] private Sprite[] _pointsSprites;
    [SerializeField] private TextMeshProUGUI _pointsUI;
    private static MonoBehaviour staticScript;
    private static Sprite[] pointsSprites;
    private static TextMeshProUGUI pointsUI;
    private static int countRolls = 0;
    void Start()
    {
        staticScript = this;
        pointsSprites = _pointsSprites;
        pointsUI = _pointsUI;
        diceIcons = new GameObject[iconsContainer.childCount];
        for (int i = 0; i < iconsContainer.childCount; i++)
            diceIcons[i] = iconsContainer.GetChild(i).gameObject;
    }
    public static void ShowAdditivePoints(int result)
    {
        staticScript.StartCoroutine(ShowResults(result));
    }
    static IEnumerator ShowResults(int result)
    {
        pointsUI.text = "+" + result;

        yield return new WaitForSeconds(2f);
        pointsUI.text = "";
        PointsManager.AddToPoints(result);
    }

    public static void ShowApeardPoint(int point)
    {
        diceIcons[countRolls].GetComponent<Image>().sprite = pointsSprites[point];
        countRolls++;
        if (countRolls == DiceManager.countDice)
            countRolls = 0;
        //    for (int i = 0; i < diceIcons.Length; i++)
        //        diceIcons[i].GetComponent<Image>().sprite = pointsSprites[0];

    }
    public static void ClearResults()
    {
        for (int i = 0; i < diceIcons.Length; i++)
            diceIcons[i].GetComponent<Image>().sprite = pointsSprites[0];
    }
}
