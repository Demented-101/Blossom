using System.Collections;
using System.Collections.Generic;
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
        SaveData data = new SaveData(); // load save data
        money = data.money;
    }
}
