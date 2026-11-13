using UnityEngine;

using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] private Button targetButton;
    public void ActivateOtherButton()
    {
        targetButton.onClick.Invoke();
    }
}
