using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueFroce = 10f;
    [SerializeField] private float maxTorqueFroce = 20f;
    public static int countDice = 6;
    private static int availableRolls = 0;
    int countRolls = countDice;

    private Dice[] dice;
    private Vector3[] startPositions;

    public static void ChangeAvailableRolls(int value)
    {
        availableRolls = value;
        UIManager.PrintRolls(value.ToString());
    }
    public void DiceRoll()
    {
        if (availableRolls == 0 || countRolls < countDice)
            return;
        countRolls = 0;
        ChangeAvailableRolls(availableRolls - 1);
        PointsManager.ClearPoints();
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].gameObject.transform.position = startPositions[i];
            StartCoroutine(dice[i].DieRoll(points => { PointsManager.SetPoint(points); countRolls++; }));
        }
    }
    private void PutInStartPosition(GameObject die,  Vector3 startPosition)
    {
        die.transform.position = startPosition;
    }
    private void Start()
    {
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
