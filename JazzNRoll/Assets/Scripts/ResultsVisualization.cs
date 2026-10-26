using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class ResultsVisualization : MonoBehaviour
{
    private static GameObject[] diceIcons;
    [SerializeField] private Transform iconsContainer;
    [SerializeField] private Sprite[] _pointsSprites;
    [SerializeField] private TextMeshProUGUI _pointsUI;
    private static MonoBehaviour staticScript;
    private static Sprite[] pointsSprites;
    private static TextMeshProUGUI pointsUI;
    private static int _rolledDiceCount = 0;
    void Start()
    {
        staticScript = this;
        pointsSprites = _pointsSprites;
        pointsUI = _pointsUI;
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

    public static void ShowAppearedDiceValue(int value)
    {
        diceIcons[_rolledDiceCount].GetComponent<Image>().sprite = pointsSprites[value];
        _rolledDiceCount++;
        if (_rolledDiceCount == DiceManager.diceCount)
            _rolledDiceCount = 0;
        //    for (int i = 0; i < diceIcons.Length; i++)
        //        diceIcons[i].GetComponent<Image>().sprite = pointsSprites[0];

    }
    public static void ClearResults()
    {
        for (int i = 0; i < diceIcons.Length; i++)
            diceIcons[i].GetComponent<Image>().sprite = pointsSprites[0];
    }
}
