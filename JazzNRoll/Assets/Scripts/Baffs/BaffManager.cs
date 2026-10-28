using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BaffManager : MonoBehaviour
{
    [SerializeField] Item[] _items;
    [SerializeField] Sprite[] _cardBackground;
    static Item[] usualItems;
    static Item[] rareItems;
    static Item[] legendaryItems;
    static BaffItem[] debaffs;
    static GameObject[] cards;
    static Sprite[] cardBackground;
    static List<Baff> baffs = new List<Baff>();
    static int rareChance = 40;
    static int legendaryChance = 10;
    static byte cardsCount;
    public static int pityPoints { get; private set; } = 0;
    public const int maxPity = 5;
    static byte usualUsedCount = 0;
    static byte rareUsedCount = 0;
    static byte legendaryUsedCount = 0;
    static byte debaffUsedCount = 0;
    const string TITLE = "title";
    const string DESCRIPTION = "description";
    void Start()
    {
        cardBackground = _cardBackground;
        int countUsual = 0;
        int countRare = 0;
        int countLegendary = 0;
        int countDebaff = 0;
        for (int i = 0; i < _items.Length; i++)
            if (_items[i].rarity == Rarity.usual) countUsual++;
            else if (_items[i].rarity == Rarity.rare) countRare++;
            else if (_items[i].rarity == Rarity.legendary) countLegendary++;
            else countDebaff++;
        usualItems = new Item[countUsual];
        rareItems = new Item[countRare];
        legendaryItems = new Item[countLegendary];
        debaffs = new BaffItem[countDebaff];
        foreach (Item item in _items)
            if (item.rarity == Rarity.usual) usualItems[--countUsual] = item;
            else if (item.rarity == Rarity.rare) rareItems[--countRare] = item;
            else if (item.rarity == Rarity.legendary) legendaryItems[--countLegendary] = item;
            else debaffs[--countDebaff] = item as BaffItem;
        ShuffleCards(usualItems);
        ShuffleCards(rareItems);
        ShuffleCards(legendaryItems);
        ShuffleCards(debaffs);
        cardsCount = (byte)transform.childCount;
        cards = new GameObject[cardsCount];
        for (int i = 0; i < cardsCount; i++)
            cards[i] = transform.GetChild(i).gameObject;
        SpawnNewBaffs();
    }

    public static void ActivateBaffs() {
        foreach (Baff baff in baffs)
            baff.ModifyGame();
    }

    public static void AddToPity(int value)
    {
        pityPoints += value;
        UIManager.ShowPity();
    }
    public static void AddToLegendaryChance(int value)
    {
        legendaryChance += value;
    }
    public void PickBaff(BaffCard baffCard)
    {
        //baffCard.item.baff.Start();
        baffCard.item.Start();
        if (baffCard.item is BaffItem baffItem)
        {
            baffs.Add(baffItem.baff);
            BaffVisualization.AddBaffToList(baffItem);
        }
        RoundManager.NextRound();
        switch (baffCard.item.rarity)
        {
            case Rarity.usual:
                MoveToUsed(usualItems, baffCard.item, usualUsedCount);
                usualUsedCount += 1;
                //PrintAvailableCard(usualItems, usualDropped);
                break;
            case Rarity.rare:
                MoveToUsed(rareItems, baffCard.item, rareUsedCount);
                rareUsedCount += 1;
                //PrintAvailableCard(rareItems, rareDropped);
                break;
            case Rarity.legendary:
                MoveToUsed(legendaryItems, baffCard.item, legendaryUsedCount);
                legendaryUsedCount += 1;
                //PrintAvailableCard(legendaryItems, legendaryDropped);
                break;
            case Rarity.debaff:
                MoveToUsed(debaffs, baffCard.item, debaffUsedCount);
                debaffUsedCount += 1;
                //PrintAvailableCard(legendaryItems, legendaryDropped);
                break;
        }

        ShuffleCards(usualItems, usualUsedCount);
        ShuffleCards(rareItems, rareUsedCount);
        ShuffleCards(legendaryItems, legendaryUsedCount);
        ShuffleCards(debaffs, debaffUsedCount);
    }
    //private static void PrintAvailableCard(BaffItem[] cards, int index)
    //{
    //    string str = "";
    //    for (int i = index; i < cards.Length; i++)
    //        str = str+ " " + cards[i].name;
    //    Debug.Log(str);
    //}
    private static void MoveToUsed(Item[] items, Item item, int index)
    {
        int itemIndex = Array.IndexOf(items, item);
        Item temp = items[index];
        items[index] = item;
        items[itemIndex] = temp;
    }
    public static void SpawnNewBaffs()
    {
        Item[] randomItems = new Item[3];
        if (pityPoints >= 0)
            randomItems = GetRandomBaffs();
        else
            randomItems = GetRandomDebaffs();
        for (int i = 0; i < cardsCount; i++)
            UpdateCard(randomItems[i], cards[i]);
    }
    private static BaffItem[] GetRandomDebaffs()
    {
        BaffItem[] randomItems = new BaffItem[cardsCount];
        
        for (byte i = 0; i < cardsCount; i++)
            randomItems[i] = GetRandomCard(debaffs, debaffUsedCount, i);
        return randomItems;
    }
    private static Item[] GetRandomBaffs()
    {
        Item[] randomItems = new Item[cardsCount];
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

    private static void UpdateCard(Item item, GameObject card)
    {
        if (item == null)
            return;
        card.GetComponent<BaffCard>().item = item;
        card.GetComponent<Image>().sprite = cardBackground[(int)item.rarity];
        for (int i = 0; i < card.transform.childCount; i++)
        {
            if (card.transform.GetChild(i).name == TITLE)
                card.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = item.title;
            if (card.transform.GetChild(i).name == DESCRIPTION)
                card.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = item.description;
            if (card.transform.GetChild(i).TryGetComponent<Image>(out Image image))
                image.sprite = item.icon;
        }

    }
    private static void ShuffleCards<T>(T[] cards, int index = 0)
    {
        T temp;
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
    private static T GetRandomCard<T>(T[] cards, byte countDropped, byte index)//может попасться два подряд одинаковых
    { 
        if (countDropped + index+1 > cards.Length)
        {
            countDropped = 0;
            ShuffleCards(cards, index);
        }
        T item = cards[countDropped + index];
       
        return item;
    }
}
