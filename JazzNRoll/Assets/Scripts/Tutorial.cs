using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] string[] tutorialTexts;
    [SerializeField] Transform[] tutorialPositions;
    [SerializeField] TextMeshProUGUI tutorialTextMesh;
    [SerializeField] Transform tutorialPanel;
    byte currentStep = 0;
    void Start()
    {
        currentStep = 0; UpdateTutorial();
    }
    public void NextStep()
    {
        currentStep++;
        if (currentStep <  tutorialTexts.Length) 
            UpdateTutorial();
        else
            this.gameObject.SetActive(false);
    }
    private void UpdateTutorial()
    {
        tutorialTextMesh.text = tutorialTexts[currentStep];
        tutorialPanel.position = tutorialPositions[currentStep].position;

    }
}
