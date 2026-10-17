using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaffManager : MonoBehaviour
{
    [SerializeField] BaffItem[] _items;
    static GameObject[] cards;
    static Baff[] baffOnCards;
    static BaffItem[] items;
    static byte countCards;
    public void ActivateBaff(int index)
    {
        baffOnCards[index].ModifyGame();
        UIManager.BaffPicked();
    }
    public static void SpawnNewBaffs()
    {

        Debug.Log("SpawnNewBaffs");
        BaffItem[] randomItems = GetRandomItems();
        for (int i = 0; i < countCards; i++)
        {
            UpdateCard(randomItems[i], cards[i]);
            baffOnCards[i] = randomItems[i].baff;
        }
    }
    private static BaffItem[] GetRandomItems()
    {
        BaffItem[] randomItems = new BaffItem[countCards];
        for (int i = 0; i < countCards; i++)
            randomItems[i] = items[i];
        return randomItems;
    }
    void Start()
    {
        items = _items;
        countCards = (byte)transform.childCount;
        cards = new GameObject[countCards];
        baffOnCards = new Baff[countCards];
        for (int i = 0; i < countCards; i++)
        {
            cards[i] = transform.GetChild(i).gameObject;
            baffOnCards[i] = new Baff();
        }
        SpawnNewBaffs();
    }

    private static void UpdateCard(BaffItem item, GameObject card)
    {
        if (item == null)
            return;
        card.GetComponent<Image>().sprite = item.cardSprite;
        for (int i = 0; i < card.transform.childCount; i++)
        {
            if (card.transform.GetChild(i).TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
                description.text = item.description;
            if (card.transform.GetChild(i).TryGetComponent<Image>(out Image image))
                image.sprite = item.icon;
        }

    }
}
