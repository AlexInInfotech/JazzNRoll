using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaffVisualization : MonoBehaviour
{
    static GameObject[] baffIcons;
    static byte activeBaffCount = 0;
    void Start()
    {
        baffIcons = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            baffIcons[i] = transform.GetChild(i).gameObject;
            baffIcons[i].SetActive(false);
        }
    }

    public static void AddBaffToList(BaffItem baff)
    {
        baffIcons[activeBaffCount].GetComponent<Image>().sprite = baff.icon;
        baffIcons[activeBaffCount].SetActive(true);
        baffIcons[activeBaffCount].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = baff.name;
        activeBaffCount++;
        //baffIcons[activeBaffCount]
    }
    
}
