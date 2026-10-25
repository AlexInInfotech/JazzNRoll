using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    Animator _animator => GetComponent<Animator>();
    static Animator animator;
    private const string BETMADE = "BetMade";
    private const string ROLLEND = "RollEnd";
    void Start()
    {
        animator = _animator;
    }
    public static void BetMade()
    {
        animator.SetTrigger(BETMADE);
    }
    public static void FinishRoll()
    {
        animator.SetTrigger(ROLLEND);
    }
}
