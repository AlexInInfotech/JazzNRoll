using UnityEngine;

public class TutorialStep : MonoBehaviour
{
    [SerializeField] private string text;

    public virtual void ActivateStep()
    {
         gameObject.SetActive(true);
    }

    public virtual void DeactivateStep()
    {
        gameObject.SetActive(false);
    }
}
