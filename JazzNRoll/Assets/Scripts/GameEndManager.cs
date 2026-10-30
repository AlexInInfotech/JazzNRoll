using UnityEngine;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] Sprite _loseSprite;
    [SerializeField] Sprite _winSprite;
    [SerializeField] private GameObject _gameEnd;
    private static GameObject gameEnd;
    static Sprite winSprite;
    static Sprite loseSprite;

    private void Awake()
    {
        gameEnd = _gameEnd;
        gameEnd.SetActive(false);
        winSprite = _winSprite;
        loseSprite = _loseSprite;
    }
    public static void EndGame(bool isWin)
    {
        if (isWin) 
            gameEnd.GetComponent<Image>().sprite = winSprite;
        else
            gameEnd.GetComponent<Image>().sprite = loseSprite;
        gameEnd.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
