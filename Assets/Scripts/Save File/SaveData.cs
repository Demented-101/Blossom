using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// this handles the data in the save file, i.e. formatting it or giving it to the variables that need it, IE PlayerData
// loading or saving the data itself is done seperately by the SaveManager
public class SaveData
{
    public int money;

    public SaveData()
    {
        money = PlayerData.money;
    }
}
