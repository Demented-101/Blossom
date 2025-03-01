using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //general
    public static int money;

    // inventory
    public static int petals;
    public static string[] inventory;

    public static Dictionary<string, int> storedFlowers;
    public static Dictionary<string, int> storedGeodes;
    public static bool[,] combinations;

    private void Start()
    {
        SaveData data = SaveManager.Load();
        money = data.money;
        inventory = data.inventory;
    }

    public bool AttemptPickup(string itemName)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            string fullname = inventory[i];
            string name = fullname.Split(';')[0];
            

            if (name == itemName)
            {
                int amount = int.Parse(fullname.Split(';')[1]);
                inventory[i] = name + (amount + 1).ToString();
                print(inventory[i]);
                return true;
            }
        }

        if (inventory.Length >= 12)
        {
            inventory.Append(itemName + ";1");
            print(inventory.ToString());
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
