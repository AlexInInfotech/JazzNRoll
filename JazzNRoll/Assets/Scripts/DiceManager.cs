using UnityEngine;
using System.Collections;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueForce = 10f;
    [SerializeField] private float maxTorqueForce = 20f;
    public static int diceCount;
    public static int remainingRolls { get; private set; } = 0;
    int _stoppedDiceCount;

    private Dice[] dice;
    private Vector3[] startPositions;
    public static void AddRolls(int value)
    {
        ChangeAvailableRolls(remainingRolls + value);
    }
    public static void ChangeAvailableRolls(int value)
    {
        remainingRolls = value;
        UIManager.PrintRemainingRolls(value.ToString());
    }
    public void DiceRoll()
    {
        if (_stoppedDiceCount < diceCount || remainingRolls <= 0)
            return;
        _stoppedDiceCount = 0;
        ChangeAvailableRolls(remainingRolls - 1);
        PointsManager.ClearPreviousResult();
        ResultsVisualization.ClearResults();
        BaffManager.ActivateBaffs();
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].gameObject.transform.position = startPositions[i];
            StartCoroutine(dice[i].DieRoll(diceValue => ValueAppeared(diceValue)));
        }
    }

    private void ValueAppeared(byte value)
    {
        PointsManager.RegisterDiceRoll(value);
        ResultsVisualization.ShowAppearedDiceValue(value);
        _stoppedDiceCount++;
        TryFinishTurn();
    }
    private void TryFinishTurn()
    {
        if (_stoppedDiceCount != diceCount)
            return;
        BaffManager.ActivateBaffs();
        if (remainingRolls > 0)
            return;
        StartCoroutine(Finish());
        //BaffManager.SpawnNewBaffs();
        //UIManager.FinishRound();
        //CameraAnimationController.FinishRound();
    }
    IEnumerator Finish()
    {
        yield return new WaitForSeconds(3f);
        ResultsVisualization.ClearResults();
        BaffManager.SpawnNewBaffs();
        UIManager.RollsFinish();
        CameraAnimationController.FinishRoll();
    }
    private void Start()
    {
        diceCount = transform.childCount;
        _stoppedDiceCount = diceCount;
        dice = new Dice[transform.childCount];
        startPositions = new Vector3[transform.childCount];
        Dice.SetMinMax(minForce, maxForce, minTorqueForce, maxTorqueForce);
        for (int i = 0; i < transform.childCount; i++)
        {
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
            startPositions[i] = transform.GetChild(i).transform.position;
        }
    }
    
}
