using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaffManager : MonoBehaviour
{
    [SerializeField] BaffItem[] _items;
    [SerializeField] Sprite[] _cardBackground;
    static BaffItem[] usualItems;
    static BaffItem[] rareItems;
    static BaffItem[] legendaryItems;
    static GameObject[] cards;
    static Sprite[] cardBackground;
    static int rareChance = 40;
    static int legendaryChance = 10;
    static byte cardsCount;

    static byte usualUsedCount = 0;
    static byte rareUsedCount = 0;
    static byte legendaryUsedCount = 0;
    public void PickBaff(BaffCard baffCard)
    {
        baffCard.baffItem.baff.ModifyGame();
        UIManager.BaffPicked();
        switch (baffCard.baffItem.rarity)
        {
            case Rarity.usual:
                MoveToUsed(usualItems, baffCard.baffItem, usualUsedCount);
                usualUsedCount += 1;
                //PrintAvailableCard(usualItems, usualDropped);
                break;
            case Rarity.rare:
                MoveToUsed(rareItems, baffCard.baffItem, rareUsedCount);
                rareUsedCount += 1;
                //PrintAvailableCard(rareItems, rareDropped);
                break;
            case Rarity.legendary:
                MoveToUsed(legendaryItems, baffCard.baffItem, legendaryUsedCount);
                legendaryUsedCount += 1;
                //PrintAvailableCard(legendaryItems, legendaryDropped);
                break;
        }

        ShuffleCards(usualItems, usualUsedCount);
        ShuffleCards(rareItems, rareUsedCount);
        ShuffleCards(legendaryItems, legendaryUsedCount);
    }
    //private static void PrintAvailableCard(BaffItem[] cards, int index)
    //{
    //    string str = "";
    //    for (int i = index; i < cards.Length; i++)
    //        str = str+ " " + cards[i].name;
    //    Debug.Log(str);
    //}
    private static void MoveToUsed(BaffItem[] items, BaffItem item, int index)
    {
        int itemIndex = Array.IndexOf(items, item);
        BaffItem temp = items[index];
        items[index] = item;
        items[itemIndex] = temp;
    }
    public static void SpawnNewBaffs()
    {
        BaffItem[] randomItems = GetRandomItems();
        for (int i = 0; i < cardsCount; i++)
            UpdateCard(randomItems[i], cards[i]);
    }
    private static BaffItem[] GetRandomItems()
    {
        BaffItem[] randomItems = new BaffItem[cardsCount];
        int randomNum = 0; 
        byte usualCount = 0;
        byte rareCount = 0;
        byte legendaryCount = 0;
        for (int i = 0; i < cardsCount; i++)
        {
            randomNum = UnityEngine.Random.Range(1, 100);
            if (randomNum >= 100 - legendaryChance)
            {
                randomItems[i] = GetRandomCard(legendaryItems, legendaryUsedCount, legendaryCount);
                legendaryCount++;
            }
            else if (randomNum <= rareChance)
            {
                randomItems[i] = GetRandomCard(rareItems, rareUsedCount, rareCount);
                rareCount++;
            }
            else
            {
                randomItems[i] = GetRandomCard(usualItems, usualUsedCount, usualCount);
                usualCount++;
            }

        }
        return randomItems;
    }
    void Start()
    {
        cardBackground = _cardBackground;
        int countUsual = 0;
        int countRare = 0;
        int countLegendary = 0;
        for(int i =0; i < _items.Length; i++)
            if (_items[i].rarity == Rarity.usual)  countUsual++;
            else if (_items[i].rarity == Rarity.rare) countRare++;
            else countLegendary++;
        usualItems = new BaffItem[countUsual];
        rareItems = new BaffItem[countRare];
        legendaryItems = new BaffItem[countLegendary];
        foreach(BaffItem item in _items)
            if (item.rarity == Rarity.usual) usualItems[--countUsual] = item;
            else if(item.rarity == Rarity.rare) rareItems[--countRare] = item;
            else legendaryItems[--countLegendary] = item;
        ShuffleCards(usualItems);
        ShuffleCards(rareItems);
        ShuffleCards(legendaryItems);
        cardsCount = (byte)transform.childCount;
        cards = new GameObject[cardsCount];
        for (int i = 0; i < cardsCount; i++)
            cards[i] = transform.GetChild(i).gameObject;
        SpawnNewBaffs();
    }

    private static void UpdateCard(BaffItem item, GameObject card)
    {
        if (item == null)
            return;
        card.GetComponent<BaffCard>().baffItem = item;
        card.GetComponent<Image>().sprite = cardBackground[(int)item.rarity];
        for (int i = 0; i < card.transform.childCount; i++)
        {
            if (card.transform.GetChild(i).TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
                description.text = item.description;
            if (card.transform.GetChild(i).TryGetComponent<Image>(out Image image))
                image.sprite = item.icon;
        }

    }
    private static void ShuffleCards(BaffItem[] cards, int index = 0)
    {
        BaffItem temp;
        int random;
        for (int j = 0; j < 4; j++)
            for (int i = index; i < cards.Length; i++)
            {
                random = UnityEngine.Random.Range(index, cards.Length);
                temp = cards[random];
                cards[random] = cards[i];
                cards[i] = temp;
            }
    }
    private static BaffItem GetRandomCard(BaffItem[] cards, byte countDropped, byte index)//может попасться два подряд одинаковых
    {
        BaffItem item = cards[countDropped + index];
        if (countDropped + index+1 > cards.Length)
        {
            countDropped = 0;
            ShuffleCards(cards, index);
        }
        return item;
    }
}
