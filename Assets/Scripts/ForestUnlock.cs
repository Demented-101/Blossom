using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestUnlock : MonoBehaviour
{
    public GameObject[] areaToUnlock; // This trigger's specific area
    public int profitThreshold;        // Profit needed to unlock this area
    private int currentProfit;

    public float range = 3;
    public PlayerMovement player;
    public bool run = true;

    public bool isUnlocked = false;    // Track this area's unlock status

    SaveData saveData;

    void Start()
    {
        SaveData data = SaveManager.Load();
        currentProfit = data.money;
        Debug.Log(currentProfit);
        LockArea();
    }

    void Update()
    {
        if (!run) return;

        Vector3 playerPosition = player.transform.position;
        if (Vector3.Distance(playerPosition, transform.position) < range && Input.GetKeyDown(KeyCode.E))
        {
            Interacted();
        }
    }

    public void Interacted()
    {
        

        if (!isUnlocked && currentProfit >= profitThreshold)
        {
            UnlockArea();
            isUnlocked = true;
            Debug.Log("Unlocked area at trigger: " + gameObject.name);
        }
        else if (isUnlocked)
        {
            Debug.Log("Area already unlocked.");
        }
        else
        {
            Debug.Log("Not enough profit to unlock this area.");
        }
    }

    void UnlockArea()
    {
        foreach (GameObject obj in areaToUnlock)
        {
            obj.SetActive(false);
        }
    }

    void LockArea()
    {
        foreach (GameObject obj in areaToUnlock)
        {
            obj.SetActive(true);
        }
    }
}
