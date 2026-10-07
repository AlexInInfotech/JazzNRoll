using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private Dice[] dice;
    [SerializeField] private float minForce = 10f;
    [SerializeField] private float maxForce = 20f;
    [SerializeField] private float minTorqueFroce = 10f;
    [SerializeField] private float maxTorqueFroce = 20f;
    public void DiceRoll()
    {
        foreach (Dice die in dice)
            StartCoroutine(die.DieRoll(points =>UpdatePoints(points, die.name)));
    }

    private void Start()
    {
        Dice.SetMinMax(minForce, maxForce, minTorqueFroce, maxTorqueFroce);
        
    }
    private void UpdatePoints(int points, string name) 
    {
        Debug.Log(points + " " + name);
    }
}
