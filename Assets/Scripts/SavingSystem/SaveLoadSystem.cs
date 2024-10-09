using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadSystem<T> where T : new()
{
    private T _data;

    public SaveLoadSystem(T data = default)
    {
        if (!typeof(T).IsSerializable)
        {
            Debug.LogError("You can't save an unserializable datas!");
        }

        _data = data;
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "save.dat");
        formatter.Serialize(fileStream, _data);
        fileStream.Close();
    }

    public T Load()
    {
        if (!File.Exists(Application.persistentDataPath + "save.dat")) return default;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + "save.dat", FileMode.Open);

        if (fileStream.Length == 0)
        {
            fileStream.Close();
            return default;
        }

        var loadedData = (T)formatter.Deserialize(fileStream);
        fileStream.Close();
        return loadedData;
    }
}
