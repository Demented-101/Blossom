using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private static bool loaded;
    //general
    public static int money;

    // inventory
    public static int petals;
    public static string[] inventory;

    public static int[] storedFlowers;
    public static int[] storedGeodes;
    public static string[] combinations;

    private void Start()
    {
        if (loaded) {return;}
        SaveData data = SaveManager.Load();
        money = data.money;
        petals = data.petals;
        inventory = data.inventory;

        storedFlowers = data.storedFlowers;
        storedGeodes = data.storedGeodes;
        combinations = data.combinations;

        loaded = true;
    }

    public bool AttemptPickup(string itemName)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            string fullname = inventory[i];
            
            if (fullname.Contains(";") && fullname.Split(";")[0] == itemName) // add to existing stack
            {
                string name = fullname.Split(';')[0];
                int amount = int.Parse(fullname.Split(';')[1]);
                inventory[i] = name + ";" + (amount + 1).ToString();
                Debug.Log("Added item to inventory in existing slot: " + fullname + " - " + itemName);
                return true;
            } 
            else if (fullname  == "") // empty slot
            {
                inventory[i] = itemName + ";1";
                Debug.Log("Added item to inventory in new slot - " + itemName);
                return true;
            }
        }
        if (inventory.Length < 12)
        {
            int size = inventory.Length + 1;
            Array.Resize(ref inventory, size);
            inventory[size - 1] = itemName + ";1";
            Debug.Log("added item to inventory in new resize slot - " + itemName);
        }

        Debug.Log("inventory full - could not add " + itemName);
        return false;
    }
}
