using System.Collections.Generic;
using UnityEngine;
public static class PointsManager 
{
    private enum ComboType { NoCombo, Pair, Set, Street, FourOfAKind,TwoPairs, Flush,  FullHouse, Royal }

    private static readonly Dictionary<ComboType, float> ComboModifiers = new Dictionary<ComboType, float>
    {
        { ComboType.NoCombo, 1.00f },
        { ComboType.Pair, 1.30f },
        { ComboType.Set, 1.75f },
        { ComboType.Street, 3.00f },
        { ComboType.FourOfAKind, 3.00f },
        { ComboType.TwoPairs, 2.25f },
        { ComboType.Flush, 5.00f },
        { ComboType.FullHouse, 3.25f },
        { ComboType.Royal, 5.00f }
    };



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
        ComboType combo = ComboType.NoCombo;
        byte paraCounter = 0;
        bool hasSet = false;
        byte streetCount = 0;
        for (int i = 0; i < pointsFromDice.Length; i++)
        {
            result += i * pointsFromDice[i];
            switch (pointsFromDice[i])
            {
                case 0:
                    streetCount = 0;
                    break;
                case 2:
                    paraCounter++;
                    if (paraCounter == 2)
                        combo = ComboType.TwoPairs;
                    break;
                case 3:
                    hasSet = true;
                    break;
                case 4:
                    combo = ComboType.FourOfAKind;
                    break;
                case 5:
                    combo = ComboType.Flush;
                    break;
            }
            if (paraCounter == 1 && combo == ComboType.NoCombo)
                if (hasSet)
                    combo = ComboType.FullHouse;
                else
                    combo = ComboType.Pair;
            if (pointsFromDice[i] != 0)
            {
                streetCount++;
                if (streetCount == 3)
                    combo = ComboType.Street;
                 else if (streetCount == 5)
                     combo = ComboType.Royal;
            }
        }
        return (int)(result* ComboModifiers.GetValueOrDefault<ComboType, float>(combo));

    }
}
