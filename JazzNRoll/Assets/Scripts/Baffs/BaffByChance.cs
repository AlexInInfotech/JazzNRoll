using System;
using UnityEngine;

public class BaffByChance : Baff
{
    [SerializeField] public int workChance;
    [SerializeField] public int additiveChance;
    [SerializeField] public byte frequencyIncreaseChance;
    byte counter = 0;
    bool isActive = false;
    protected int lastScore;
    public override void Start()
    {
        isActive = false;
        counter = 0;
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)//начало броска
        {
            if (UnityEngine.Random.Range(0, 100) < workChance + additiveChance * (int)(counter / frequencyIncreaseChance))
            {
                isActive = true;
                counter = 0;
                Activated();
            }
            else
                counter++;
            return;
        }
        if (isActive)
        {
            Deactivated();
            isActive = false;
        }
        lastScore = PointsManager.totalGainedPoints;
    }
    protected virtual void Activated()
    {
        return;
    }
    protected virtual void Deactivated()
    {
        return;
    }
}
