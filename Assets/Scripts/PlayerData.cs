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
    public static string[] inventory;

    private void Start()
    {
        if (loaded) {return;}
        SaveData data = SaveManager.Load();
        money = data.money;
        inventory = data.inventory;

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

    public void RemoveItem(string itemName, int amount)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            string fullname = inventory[i];

            if (fullname.Contains(";") && fullname.Split(";")[0] == itemName)
            {
                string name = fullname.Split(';')[0];
                int oldAmount = int.Parse(fullname.Split(";")[1]);

                inventory[i] = name + ";" + (oldAmount - amount).ToString();
                return;
            }
        }
    }

    public int GetItemAmount(string itemName)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].Contains(itemName))
            {
                Debug.Log(inventory[i].Split(";")[1]);
                return int.Parse(inventory[i].Split(";")[1]);
            }
        }
        return 0;
    }
}
