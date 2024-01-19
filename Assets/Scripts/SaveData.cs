using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "save.dat");
        formatter.Serialize(fileStream, Scoring.Highscore);
        fileStream.Close();
    }

    public static void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "save.dat")) return;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + "save.dat", FileMode.Open);
        Scoring.Highscore = (int)formatter.Deserialize(fileStream);
        fileStream.Close();
    }
}
