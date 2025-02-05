using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int sceneChanges;
    public static int money;

    private void Start()
    {
        sceneChanges += 1;

        SaveData data = new SaveData(); // load save data
        money = data.money;
    }
}
