using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class PointsManager 
{
    private static int currentPoints = 0;
    private static int[] pointsFromDice = new int[6+1];
    private static int countRolls = 0;
   
    public static void AddToPoints(int value)
    {
        currentPoints += value;
        UIManager.PrintPoints(currentPoints.ToString());
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
        if (countRolls == DiceManager.countDice)
            AddToPoints(CountResult());

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
