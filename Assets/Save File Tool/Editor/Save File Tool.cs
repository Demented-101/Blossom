using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveFileTool : EditorWindow
{
    public string itemName = "";
    public int itemCount = 1;

    [MenuItem("Tools/Custom Tools/Save File Tool")]
    public static void ShowWindow(){
        GetWindow(typeof(SaveFileTool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Save File Tool");

        if (GUILayout.Button("Wipe Inventory")) { WipeInventory(); }

        itemName = EditorGUILayout.TextField(itemName);
        itemCount = EditorGUILayout.IntField(itemCount);
        if (GUILayout.Button("Add Item to Inventory")) { AddItemInventory(); }

    }

    private SaveData LoadData(string path)
    {
        SaveData data = new SaveData(); // load save file
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, data);
        return data;
    }

    private void SaveJson(SaveData data, string path)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    private void WipeInventory()
    {
        string path = Application.persistentDataPath + "/player.json"; // get the file path
        SaveData data;
        if (File.Exists(path)) // file is there
        {
            data = LoadData(path);
            data.inventory = new string[12]; // clear the inventory
            SaveJson(data, path);

            Debug.Log("wiped inventory");
        }
        else
        {
            Debug.LogError("File location doesnt exist");
        }

    }
    
    private void AddItemInventory()
    {
        string path = Application.persistentDataPath + "/player.json"; // get the file path
        SaveData data = LoadData(path);

        if (data.inventory.Length != 12) { Array.Resize(ref data.inventory, 12); }

        for (int i = 0; i < 12; i++)
        {
            string fullname = data.inventory[i];
            string name = fullname.Split(';')[0];

            if (name == itemName) // add to existing stack
            {
                int amount = int.Parse(fullname.Split(';')[1]);
                data.inventory[i] = name + ";" + (amount + itemCount).ToString();
                Debug.Log("Added item to inventory in existing slot: " + fullname + " - " + itemName);

                SaveJson(data, path);
                return;
            }
            else if (fullname == "") // empty slot
            {
                data.inventory[i] = itemName + ";" + itemCount.ToString();
                Debug.Log("Added item to inventory in new slot inside loop - " + itemName);

                SaveJson(data, path);
                return;
            }
        }
        Debug.Log("inventory full - cannot remove");

    }
}

