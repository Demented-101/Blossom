using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;


public class StoreUIScript : MonoBehaviour
{
    private int currentFlower = -1;
    private int currentGeode = -1;
    public int price = 0;

    private PlayerData playerData;

    public GameObject priceLabel;
    public GameObject flowerAmountLabel;
    public GameObject geodeAmountLabel;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        flowerAmountLabel.GetComponent<TextMeshProUGUI>().text = "";
        geodeAmountLabel.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void SelectFlower(int flowerIndex)
    {
        currentFlower = flowerIndex;
        flowerAmountLabel.GetComponent<TextMeshProUGUI>().text = "amount:" + playerData.GetItemAmount(IndexToFlowerName(flowerIndex)).ToString();

        SelectGeode(0);
    }

    public void SelectGeode(int geodeIndex) 
    { 
        currentGeode = geodeIndex;

        string geodeName = IndexToGeodeName(geodeIndex);
        if (geodeName != "Null")
        {
            geodeAmountLabel.GetComponent<TextMeshProUGUI>().text = "amount:" + playerData.GetItemAmount(geodeName).ToString();
        } else
        {
            geodeAmountLabel.GetComponent<TextMeshProUGUI>().text = "";
        }

        RecalculatePrice();
    }

    private void RecalculatePrice()
    {
        int flowerPrice = 10;
        flowerPrice += (int)(currentFlower * 2.5);
        int geodePrice = currentGeode;

        price = geodePrice + flowerPrice;
        priceLabel.GetComponent<TextMeshProUGUI>().text = "£" + price.ToString() + ".00";
    }

    public void AttemptSale(int amount)
    {
        Debug.Log("Sell attempt");

        string flowerName = IndexToFlowerName(currentFlower);
        string geodeName = IndexToGeodeName(currentGeode);

        int flowerCount = playerData.GetItemAmount(flowerName);
        int geodeCount = 100;
        if (IndexToGeodeName(currentGeode) != "Null") { geodeCount = playerData.GetItemAmount(geodeName); }

        if (flowerCount < amount) { Debug.Log("Not enough flowers!"); }
        if (geodeCount < amount) { Debug.Log("Not enough geodes!"); }

        if (flowerCount >= amount && geodeCount >= amount)
        {
            Debug.Log("Successful sale!");

            playerData.RemoveItem(flowerName, amount);
            playerData.RemoveItem(geodeName, amount);

            PlayerData.money += price * amount;
            SaveManager.Save();
        }

        RecalculatePrice();
        flowerAmountLabel.GetComponent<TextMeshProUGUI>().text = "amount:" + playerData.GetItemAmount(flowerName).ToString();
        if (geodeName != "Null"){ geodeAmountLabel.GetComponent<TextMeshProUGUI>().text = "amount:" + playerData.GetItemAmount(geodeName).ToString(); }
        else                    { geodeAmountLabel.GetComponent<TextMeshProUGUI>().text = ""; }
    }

    private string IndexToFlowerName(int index)
    {
        switch (index)
        {
            case 0: return "Rose";
            case 1: return "Tulip";
            case 2: return "Daisy";
            case 3: return "Sweetpea";
            case 4: return "Orchid";
            case 5: return "Nightshade";
            case 6: return "Foxglove";
            case 7: return "Lily of the Valley";
        }
        return "Null";
    }
    private string IndexToGeodeName(int index)
    {
        switch (index)
        {
            case 0: return "Null";
            case 1: return "Amythest";
            case 2: return "Quartz";
            case 3: return "Iron";
            case 4: return "Citrine";
            case 5: return "Manganese";
            case 6: return "Serpentine";
            case 7: return "Jade";
            case 8: return "Asurine";
            case 9: return "Obsidian";
            case 10: return "Bismuth";
            case 11: return "Gold";
        }
        return "Null";
    }


}
