using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class JsonHandler
{
    private static Dictionary<string, string> _jsonDictionary;

    static JsonHandler()
    {
        Load();

        _jsonDictionary ??= new();
    }

    public static string GetJsonById(string id)
    {
        return _jsonDictionary.TryGetValue(id, out var json) ? json : "";
    }

    public static bool SetJsonValueById(string id, string newJson)
    {
        _jsonDictionary[id] = newJson;
        Save();

        return true;
    }

    private static void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "save.dat")) return;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + "save.dat", FileMode.Open);

        if (fileStream.Length == 0)
        {
            fileStream.Close();
            return;
        }

        _jsonDictionary = (Dictionary<string, string>)formatter.Deserialize(fileStream);
        fileStream.Close();
    }

    private static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "save.dat");
        formatter.Serialize(fileStream, _jsonDictionary);
        fileStream.Close();
    }
}
