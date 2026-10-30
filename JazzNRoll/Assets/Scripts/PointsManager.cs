using System.Collections.Generic;
using UnityEngine;
public enum ComboType { NoCombo, Pair, Set, Street, FourOfAKind,TwoPairs, Flush,  FullHouse, Royal }
public static class PointsManager 
{
    //public static bool IsNumsInDropped(byte[] nums)
    //{
    //    byte count = 0;
    //    foreach (byte num in nums)
    //        count += (byte)diceFaceCounts[num];
    //    return count != 0;
    //}
    public static byte CountNumInDropped(byte num)
    {
        if (num >0 && num <=6)
            return diceFaceCounts[num];
        return 0;
    }
    public static void AddToComboModifiers(float value, ComboType[] types = null)
    {
        if (types == null)
            types = (ComboType[])System.Enum.GetValues(typeof(ComboType));
        for (int i = 0; i < types.Length; i++)
            if (types[i] != ComboType.NoCombo)
                ComboModifiers[types[i]] += value;
        UIManager.UpdateKoefsVisualization();
    }
    public static Dictionary<ComboType, float> ComboModifiers { get; private set; } = new Dictionary<ComboType, float>
    {
        { ComboType.NoCombo, 1.00f },
        { ComboType.Pair, 2f },
        { ComboType.Set, 3.75f },
        { ComboType.Street, 1.25f },
        { ComboType.FourOfAKind, 4.5f },
        { ComboType.TwoPairs, 3.25f },
        { ComboType.Flush, 8.50f },
        { ComboType.FullHouse, 4.25f },
        { ComboType.Royal, 5.00f }
    };

    public static int totalGainedPoints { get; private set; }
    public static ComboType[] currentCombos { get; private set; } = new ComboType[2];


    private static int currentScore = 0;
    private static byte[] diceFaceCounts = new byte[6+1];
    private static int rolledDiceCount = 0;
   public static int GetScore()
    {
        return currentScore;
    }
    public static void AddToScore(int value)
    {
        currentScore += value;
        UIManager.PrintScore(currentScore.ToString());
    }
    public static void ClearPreviousResult()
    {
        currentCombos[0] = ComboType.NoCombo;
        currentCombos[1] = ComboType.NoCombo;
        rolledDiceCount = 0;
        for (int i = 0; i < diceFaceCounts.Length; i++) 
            diceFaceCounts[i] = 0;
    }
    public static void RegisterDiceRoll(byte value)
    {
        diceFaceCounts[value]++;
        rolledDiceCount++;
        if (rolledDiceCount == DiceManager.diceCount)
        {
            int result = CountResult();
            ResultsVisualization.ShowGainedPoints(result);
            totalGainedPoints += result;
        }
            //AddToPoints(CountResult());

    }

    
    private static int CountResult()
    {
        int result = 0;
        currentCombos[0] = ComboType.NoCombo;
        currentCombos[1] = ComboType.NoCombo;
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
                        currentCombos[0] = ComboType.TwoPairs;
                    break;
                case 3:
                    hasSet = true;
                    break;
                case 4:
                    currentCombos[0] = ComboType.FourOfAKind;
                    break;
                case 5:
                    currentCombos[0] = ComboType.Flush;
                    break;
            }
            //if (pairCount == 1 && combo == ComboType.NoCombo)
            //    if (hasSet)
            //        combo = ComboType.FullHouse;
            //    else
            //        combo = ComboType.Pair;
            //else if (hasSet && combo == ComboType.NoCombo)
            //    combo = ComboType.Set;
            if (diceFaceCounts[i] != 0)
            {
                streetCount++;
                if (streetCount == 3)
                    currentCombos[1] = ComboType.Street;
                else if (streetCount == 5)
                {
                    currentCombos[0] = ComboType.Royal;
                    currentCombos[1] = ComboType.NoCombo;
                }
            }
        }

        if (pairCount == 1 && hasSet)
            currentCombos[0] = ComboType.FullHouse;
        else if(pairCount == 1)
            currentCombos[0] = ComboType.Pair;
        else if (hasSet)
            currentCombos[0] = ComboType.Set;

        Debug.Log(currentCombos[0] + " " + currentCombos[1]);



        return (int)(result* ComboModifiers.GetValueOrDefault<ComboType, float>(currentCombos[0]) * ComboModifiers.GetValueOrDefault<ComboType, float>(currentCombos[1]));

    }
}
