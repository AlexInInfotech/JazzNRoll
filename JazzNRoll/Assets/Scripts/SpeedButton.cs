using UnityEngine;

public class SpeedButton : MonoBehaviour
{
   public void ChangeSpeed(bool isActivated)
    {
        if (isActivated)
            Time.timeScale = 2f;
        else
            Time.timeScale = 1;
    }
}
