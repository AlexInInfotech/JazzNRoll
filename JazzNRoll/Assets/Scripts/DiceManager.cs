using UnityEngine;

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
        if (_stoppedDiceCount < diceCount)
            return;
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
        if (_remainingRolls != 0 || _stoppedDiceCount != diceCount)
            return;
        BaffManager.SpawnNewBaffs();
        UIManager.FinishRound();
        CameraAnimationController.FinishRound();

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
