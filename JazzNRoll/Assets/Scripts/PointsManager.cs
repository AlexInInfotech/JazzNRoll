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
    private static int[] diceFaceCounts = new int[6+1];
    private static int rolledDiceCount = 0;
   
    public static void AddToPoints(int value)
    {
        currentPoints += value;
        UIManager.PrintPoints(currentPoints.ToString());
    }
    public static void ClearPoints()
    {
        rolledDiceCount = 0;
        for (int i = 0; i < diceFaceCounts.Length; i++) 
            diceFaceCounts[i] = 0;
    }
    public static void RegisterDiceRoll(int value)
    {
        diceFaceCounts[value]++;
        rolledDiceCount++;
        if (rolledDiceCount == DiceManager.diceCount)
            ResultsVisualization.ShowGainedPoints(CountResult());
            //AddToPoints(CountResult());

    }
    
    private static int CountResult()
    {
        int result = 0;
        ComboType combo = ComboType.NoCombo;
        byte pairCount = 0;
        bool hasSet = false;
        byte streetCount = 0;
        for (int i = 0; i < diceFaceCounts.Length; i++)
        {
            result += i * diceFaceCounts[i];
            switch (diceFaceCounts[i])
            {
                case 0:
                    streetCount = 0;
                    break;
                case 2:
                    pairCount++;
                    if (pairCount == 2)
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
            if (pairCount == 1 && combo == ComboType.NoCombo)
                if (hasSet)
                    combo = ComboType.FullHouse;
                else
                    combo = ComboType.Pair;

            if (hasSet && combo == ComboType.NoCombo)
                combo = ComboType.Set;
            if (diceFaceCounts[i] != 0)
            {
                streetCount++;
                if (streetCount == 3)
                    combo = ComboType.Street;
                 else if (streetCount == 5)
                     combo = ComboType.Royal;
            }
        }
        Debug.Log(combo);
        return (int)(result* ComboModifiers.GetValueOrDefault<ComboType, float>(combo));

    }
}
