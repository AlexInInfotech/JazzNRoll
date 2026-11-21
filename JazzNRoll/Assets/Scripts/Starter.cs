using UnityEngine;
using static DiceManager;

public class Starter : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    void Start()
    {
        UIAnimations.Start(this);
        FallenDice.canvas = mainCanvas;

    }

}
