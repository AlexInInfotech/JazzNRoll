using System;
using UnityEngine;

public class BaffByChance : Baff
{
    [SerializeField] public int workChance;
    [SerializeField] public int additiveChance;
    bool isActive = false;
    protected int lastScore;
    public override void Start()
    {
        lastScore = PointsManager.totalGainedPoints;
    }
    public override void ModifyGame()
    {
        if (PointsManager.totalGainedPoints == lastScore)//начало броска
        {
            if (UnityEngine.Random.Range(0, 100) < workChance)
            {
                isActive = true;
                Activated();
            }
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
