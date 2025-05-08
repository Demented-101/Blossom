using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestUnlock : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] Area1, Area2, Area3, Area4, Area5;
    private int[] profitThresholds = { 100, 300, 500, 700, 1000 };
    private int currentProfit;

    SaveData saveData;

    void Start()
    {
        Area1 = new GameObject[0];
        Area2 = new GameObject[1];
        Area3 = new GameObject[2];
        Area4 = new GameObject[3];
        Area5 = new GameObject[4];

        currentProfit = saveData.money;

        LockAllAreas();
    }

    void Unlock()
    {
        if (currentProfit >= profitThresholds[0])
        {
            UnlockArea(Area1);
        }
        if (currentProfit >= profitThresholds[1])
        {
            UnlockArea(Area2);
        }
        if (currentProfit >= profitThresholds[2])
        {
            UnlockArea(Area3);
        }
        if (currentProfit >= profitThresholds[3])
        {
            UnlockArea(Area4);
        }
        if (currentProfit >= profitThresholds[4])
        {
            UnlockArea(Area5);
        }
    }


    void UnlockArea(GameObject[] area)
    {
        foreach (GameObject obj in area)
        {
            obj.SetActive(false);
        }
    }

    void LockAllAreas()
    {
        foreach (GameObject obj in Area1) obj.SetActive(true);
        foreach (GameObject obj in Area2) obj.SetActive(true);
        foreach (GameObject obj in Area3) obj.SetActive(true);
        foreach (GameObject obj in Area4) obj.SetActive(true);
        foreach (GameObject obj in Area5) obj.SetActive(true);
    
    }

    // Update is called once per frame
    void Update()
    {
        Unlock();
    }
}
