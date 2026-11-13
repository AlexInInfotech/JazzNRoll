
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    const string SCENENAME = "MainScene";
    public void StartGame()
    {
        SceneManager.LoadScene(SCENENAME);
    }
    public void SetTutorialActive(bool value)
    {
        Tutorial.isActive = value;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
