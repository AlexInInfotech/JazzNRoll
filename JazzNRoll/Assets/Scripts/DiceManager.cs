using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueFroce = 10f;
    [SerializeField] private float maxTorqueFroce = 20f;
    public static int countDice;
    private static int availableRolls = 0;
    int countStaticDice;

    private Dice[] dice;
    private Vector3[] startPositions;

    public static void ChangeAvailableRolls(int value)
    {
        availableRolls = value;
        UIManager.PrintRolls(value.ToString());
    }
    public void DiceRoll()
    {
        if (countStaticDice < countDice)
            return;
        countStaticDice = 0;
        ChangeAvailableRolls(availableRolls - 1);
        PointsManager.ClearPoints();
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].gameObject.transform.position = startPositions[i];
            StartCoroutine(dice[i].DieRoll(points => { PointsManager.SetPoint(points); countStaticDice++; FinishRoll(); }));
        }
    }
    private void FinishRoll()
    {
        if (availableRolls != 0 || countStaticDice != countDice)
            return;
        BaffManager.SpawnNewBaffs();
        UIManager.FinishRound();
        CameraAnimationController.FinishRoll();

    }
    private void PutInStartPosition(GameObject die,  Vector3 startPosition)
    {
        die.transform.position = startPosition;
    }
    private void Start()
    {
        countDice = transform.childCount;
        countStaticDice = countDice;
        dice = new Dice[transform.childCount];
        startPositions = new Vector3[transform.childCount];
        Dice.SetMinMax(minForce, maxForce, minTorqueFroce, maxTorqueFroce);
        for (int i = 0; i < transform.childCount; i++)
        {
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
            startPositions[i] = transform.GetChild(i).transform.position;
        }
    }
    
}
