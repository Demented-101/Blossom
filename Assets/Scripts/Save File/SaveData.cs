using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// this handles the data in the save file, i.e. formatting it or giving it to the variables that need it, IE PlayerData
// loading or saving the data itself is done seperately by the SaveManager
public class SaveData
{
    public int money;
    public string[] inventory;
    // ORDER: Rose, Tulip, Daisy, Sweet-pea, Orchid, nightshade, foxglove, lily OTV
    // ORDER: Amythest, Quartz, Iron,, Citrine, Manganese, Serpentine, Jade,, Azurine, Obsidian, Bismuth, Gold

    public void loadFromPlayer()
    {
        money = PlayerData.money;
        inventory = PlayerData.inventory;
    }

    public void loadBasics()
    {
        // set basic variables
        money = 100;
        inventory = new string[12]; // 12 is inventory size
    }
}
