using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsUI;
    private static TextMeshProUGUI pointsUI;
    private static int currentPoints = 0;
    private static int[] pointsFromDice = new int[6+1];
    private static int countRolls = 0;

    private void Start()
    {
        pointsUI = _pointsUI;
    }
    public static void ClearPoints()
    {
        countRolls = 0;
        for (int i = 0; i < pointsFromDice.Length; i++) 
            pointsFromDice[i] = 0;
    }
    public static void SetPoint(int point)
    {
        pointsFromDice[point]++;
        countRolls++;
        if (countRolls == DiceManager.currentNumberOfRolls)
            UpdatePoints();

    }
    private static void UpdatePoints()
    {
        currentPoints += CountResult();
        pointsUI.text = currentPoints.ToString();

    }
    private static int CountResult()
    {
        int result = 0;
        int koef = 1;
        //byte paraCounter = 0;
        //byte setCounter = 0;
        for (int i = 0;i < pointsFromDice.Length; i++)
        {
            result += i * pointsFromDice[i];
            //if (pointsFromDice[i] == 2)
            //    paraCounter++;
            //if (pointsFromDice[i] == 3)
            //    setCounter++;
        }





        return result* koef;

    }
}
