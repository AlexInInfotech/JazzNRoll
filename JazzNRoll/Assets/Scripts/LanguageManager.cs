
using System;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public static event Action languageChanged;
    public static Language language { get; private set; } = Language.ru;
    public enum Language { ru = 0, en, length}
    [SerializeField] Sprite[] sprites;
    public void ChangeLanguage()
    {
        GetComponent<Image>().sprite = sprites[(int)language];
        language++;
        if (language == Language.length)
            language = Language.ru;
        languageChanged?.Invoke();
    }

}
