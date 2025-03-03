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
    public Dictionary<string, int> storedFlowers;
    public Dictionary<string, int> storedGeodes;
    public bool[,] combinations;

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
        inventory = new string[12] {"", "", "", "", "", "", "", "", "", "", "", "", }; // 12 is inventory size

        // load dictionaries
        storedFlowers = new Dictionary<string, int> {
            {"Rose", 0}, {"Daisy", 0}, {"Tulip", 0}, {"Peony", 0}, {"Sweet Pea", 0}, {"Orchid", 0}, {"Nightshade", 0}, {"Foxglove", 0}, {"Lily of the Valley", 0}
        };
        storedGeodes = new Dictionary<string, int> {
            {"Amythest", 0}, {"Iron", 0}, {"Quartz", 0}, {"Citrine", 0}, {"Manganese", 0}, {"Serpentine", 0}, {"Azurite", 0}, {"Bismuth", 0}, {"Gold", 0},
        };

        // load combinations
        combinations = new bool[storedFlowers.Count, storedGeodes.Count];
        for (int i = 0; i < storedFlowers.Count; i++){
            for (int j = 0; i < storedGeodes.Count; i++){ combinations[i,j] = false; }
        }
    }
}
