using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueFroce = 10f;
    [SerializeField] private float maxTorqueFroce = 20f;
    public static int currentNumberOfRolls = 6;

    private Dice[] dice;
    public void DiceRoll()
    {
        PointsManager.ClearPoints();
        for (int i = 0; i < dice.Length; i++)
            StartCoroutine(dice[i].DieRoll(points => PointsManager.SetPoint(points)));
        //foreach (Dice die in dice)
        //    StartCoroutine(die.DieRoll(points =>UpdatePoints(points, die.name)));
    }

    private void Start()
    {
        dice = new Dice[transform.childCount];
        Dice.SetMinMax(minForce, maxForce, minTorqueFroce, maxTorqueFroce);
        for (int i = 0; i< transform.childCount; i++)
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
    }
    
}
