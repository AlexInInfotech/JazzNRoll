using TMPro;
using UnityEngine;

public class TextItem : MonoBehaviour
{
    [SerializeField] string[] texts;
    void Start()
    {
        LanguageManager.languageChanged+= onLanguageChanged;
        onLanguageChanged();
    }
    private void onLanguageChanged()
    {
        if(GetComponent<TextMeshProUGUI>() != null)
            GetComponent<TextMeshProUGUI>().text = texts[(int)LanguageManager.language];
        else
            GetComponent<TextMeshPro>().text = texts[(int)LanguageManager.language];

    }
}
