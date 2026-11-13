using UnityEngine;

public class StepAfterRolls : TutorialStep
{
    public override void ActivateStep()
    {
        DiceManager.OnAllRollsEnded += OnDiceFinished;
    }

    private void OnDiceFinished()
    {
        DiceManager.OnAllRollsEnded -= OnDiceFinished;

        base.ActivateStep();
    }
}
