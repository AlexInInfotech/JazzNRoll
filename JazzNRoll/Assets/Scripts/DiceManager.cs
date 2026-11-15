using UnityEngine;
using System.Collections;
using System;

public class DiceManager : MonoBehaviour
{
    public static event Action OnAllRollsEnded; // IMBAAAAAAAAAAAAAAAAAAAA
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueForce = 10f;
    [SerializeField] private float maxTorqueForce = 20f;
    public static int diceCount;
    public static int remainingRolls { get; private set; } = 0;

    private int _stoppedDiceCount;
    private static Dice[] dice;
    private Vector3[] startPositions;
    static byte unchangedIndex = 0;

    static FallenDice[] fallenDices;
    public class FallenDice
    {
        public FallenDice(GameObject _diceObject, byte _value)
        {
            diceMaterial = _diceObject.GetComponent<MeshRenderer>().material;
            value = _value;
        }
        public FallenDice(Material _diceMaterial, byte _value)
        {
            diceMaterial = _diceMaterial;
            value = _value;
        }
        public Material diceMaterial;
        public byte value;
    }
    public static void ChangeDice(DiceInfo diceInfo)
    {
        dice[unchangedIndex].valueOnFaces = diceInfo.valueOnFaces;
        dice[unchangedIndex].transform.GetComponent<MeshRenderer>().material = diceInfo.material;
        unchangedIndex++;
        if (unchangedIndex >= diceCount)
            unchangedIndex = 0;
    }
    public static void AddRollsWithoutShow(int value)
    {
        remainingRolls += value;
    }
    public static void ShowRolls()
    {

         UIManager.PrintRemainingRolls(remainingRolls.ToString());
    }
    public static void AddRolls(int value)
    {
        remainingRolls += value;
        UIManager.PrintRemainingRolls(remainingRolls.ToString());
    }
    public void DiceRoll()
    {
        if (_stoppedDiceCount < diceCount || remainingRolls <= 0)
            return;
        _stoppedDiceCount = 0;
        ResetComboDices();
        AddRolls( -1 );
        PointsManager.ClearPreviousResult();
        ResultsVisualization.ClearResults();
        BaffManager.ActivateBaffs();
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].gameObject.transform.position = startPositions[i];
            StartCoroutine(dice[i].DieRoll(fallenDice => {  fallenDices[_stoppedDiceCount] = new FallenDice(fallenDice.diceMaterial, fallenDice.value); ValueAppeared(fallenDice.value); }));
        }
    }
    public static void ResetComboDices()
    {
        foreach (FallenDice dice in fallenDices)
            if (dice != null)
                dice.diceMaterial.DisableKeyword("_EMISSION");
            else
                return;
                    
            
    }
    public static void ShowComboDices(byte[] comboNumbers)
    {
        for (int i = 0; i < comboNumbers.Length; i++)
            foreach (FallenDice dice in fallenDices)
                if (dice.value == comboNumbers[i])
                    dice.diceMaterial.EnableKeyword("_EMISSION");
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
        ResetComboDices();
        ResultsVisualization.ClearResults();
        BaffManager.SpawnNewBaffs();
        UIManager.RollsFinish();
        CameraAnimationController.FinishRoll();
        OnAllRollsEnded?.Invoke();
    }
    private void Start()
    {
        diceCount = transform.childCount;
        fallenDices = new FallenDice[diceCount];
        _stoppedDiceCount = diceCount;
        dice = new Dice[diceCount];
        startPositions = new Vector3[diceCount];
        Dice.SetMinMax(minForce, maxForce, minTorqueForce, maxTorqueForce);
        for (int i = 0; i < transform.childCount; i++)
        {
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
            startPositions[i] = transform.GetChild(i).transform.position;
        }
    }
    
}
