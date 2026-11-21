using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] Sprite _loseSprite;
    [SerializeField] string[] _loseTexts;
    [SerializeField] string[] _loseButtonTexts;
    [SerializeField] Sprite _winSprite;
    [SerializeField] string[] _winTexts;
    [SerializeField] string[] _winButtonTexts;
    [SerializeField] private GameObject _gameEnd;
    private static GameObject gameEnd;
    static Sprite winSprite;
    static Sprite loseSprite;
    static string[] loseTexts;
    static string[] loseButtonTexts;
    static string[] winTexts;
    static string[] winButtonTexts;

    private void Awake()
    {
        loseTexts = _loseTexts;
        loseButtonTexts = _loseButtonTexts;
        winTexts = _winTexts;
        winButtonTexts = _winButtonTexts;
        gameEnd = _gameEnd;
        gameEnd.SetActive(false);
        winSprite = _winSprite;
        loseSprite = _loseSprite;
    }
    public static void EndGame(bool isWin)
    {
        string text = "";
        string buttonText = "";
        if (isWin)
        {
            gameEnd.GetComponent<Image>().sprite = winSprite;
            text = winTexts[(int)LanguageManager.language];
            buttonText = winButtonTexts[(int)LanguageManager.language];
            
        }
        else
        {
            gameEnd.GetComponent<Image>().sprite = loseSprite;
            text = loseTexts[(int)LanguageManager.language];
            buttonText = loseButtonTexts[(int)LanguageManager.language];
        }
        if (gameEnd.transform.GetChild(0).TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI textMesh))
        {
            textMesh.text = text;
            gameEnd.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        }
        else
        {
            gameEnd.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
            gameEnd.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        }
        gameEnd.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
