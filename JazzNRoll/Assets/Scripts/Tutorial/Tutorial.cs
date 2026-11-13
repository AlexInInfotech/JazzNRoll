using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static bool isActive = true;
    [SerializeField] string[] tutorialTexts;
    TutorialStep[] tutorialSteps;
    byte currentStep = 0;


    void Start()
    {
        if(!isActive)
            this.gameObject.SetActive(false);
        currentStep = 0; 
        tutorialSteps = new TutorialStep[transform.childCount];
        for (int i =0; i < transform.childCount; i++)
        {

            tutorialSteps[i] = transform.GetChild(i).GetComponent<TutorialStep>();
            tutorialSteps[i].DeactivateStep();
        }
        UpdateTutorial();
    }
    public void NextStep()
    {
        currentStep++;
        if (currentStep < tutorialSteps.Length) 
            UpdateTutorial();
        else
            this.gameObject.SetActive(false);
    }
    private void UpdateTutorial()
    {
        Debug.Log("Next step");
        if (currentStep > 0)
            tutorialSteps[currentStep - 1].DeactivateStep();
        tutorialSteps[currentStep].ActivateStep();
        //tutorialTextMesh.text = tutorialTexts[currentStep];
        //tutorialPanel.position = tutorialPositions[currentStep].position;

    }
}
