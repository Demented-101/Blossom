using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// this handles saving and loading the data from the binary file itself
// formatting the data is done seperately by the SaveData class

public static class SaveManager 
{
    private const string fileName = "/player.demented";

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + fileName; // get the file path
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();
        data.loadFromPlayer(); // create save data class - formatting handled in constructor
        formatter.Serialize(stream, data); // write to the file
        stream.Close();
    }

    public static SaveData Load()
    {
        string path = Application.persistentDataPath + fileName; // get the file path
        if (File.Exists(path)) // file is there
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Close();

            SaveData data = formatter.Deserialize(stream) as SaveData; // turn the loaded binary into usable data - IE SaveData
            return data;
        }
        else
        {
            SaveData data = new SaveData()
            data.loadBasics()
            Debug.LogError("no save file found at path!");
            Debut.LogError("Created new save");
            Debug.LogError(path);
            return data;
        }
    }

}
