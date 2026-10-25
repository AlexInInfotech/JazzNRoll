using UnityEngine;
using System.Collections;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueForce = 10f;
    [SerializeField] private float maxTorqueForce = 20f;
    public static int diceCount;
    private static int _remainingRolls = 0;
    int _stoppedDiceCount;

    private Dice[] dice;
    private Vector3[] startPositions;

    public static void ChangeAvailableRolls(int value)
    {
        _remainingRolls = value;
        UIManager.PrintRemainingRolls(value.ToString());
    }
    public void DiceRoll()
    {
        if (_stoppedDiceCount < diceCount || _remainingRolls == 0)
            return;
        BaffManager.ActivateBaffs();
        _stoppedDiceCount = 0;
        ChangeAvailableRolls(_remainingRolls - 1);
        PointsManager.ClearPoints();
        ResultsVisualization.ClearResults();
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].gameObject.transform.position = startPositions[i];
            StartCoroutine(dice[i].DieRoll(diceValue => ValueAppeared(diceValue)));
        }
    }

    private void ValueAppeared(int value)
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
        if (_remainingRolls != 0)
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
