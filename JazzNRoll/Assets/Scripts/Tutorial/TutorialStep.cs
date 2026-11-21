using UnityEngine;

public class TutorialStep : MonoBehaviour
{

    public virtual void ActivateStep()
    {
         gameObject.SetActive(true);
    }

    public virtual void DeactivateStep()
    {
        gameObject.SetActive(false);
    }
}
