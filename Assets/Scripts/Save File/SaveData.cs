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
    public int petals;
    public string[] inventory;
    public int[] storedFlowers; // ORDER: Rose, Tulip, Daisy, Sweet-pea, Orchid, nightshade, foxglove, lily OTV
    public int[] storedGeodes; // ORDER: Amythest, Quartz, Iron, Citrine, Manganese, Serpentine, Jade, Azurine, Obsidian, Bismuth, Gold
    public string[] combinations; // ordered by flower. if index one has "Am;Qu;Cit;", then the rose has amythest, quartz and citrine unlocked.

    public void loadFromPlayer()
    {
        money = PlayerData.money;

        petals = PlayerData.petals;
        inventory = PlayerData.inventory;
        storedFlowers = PlayerData.storedFlowers;
        storedGeodes = PlayerData.storedGeodes;
        combinations = PlayerData.combinations;
    }

    public void loadBasics()
    {
        // set basic variables
        money = 0;
        petals = 0;
        inventory = new string[12]; // 12 is inventory size

        // load dictionaries
        storedFlowers = new int[8];
        storedGeodes = new int[10];

        // load combinations
        combinations = new string[9];
    }
}
