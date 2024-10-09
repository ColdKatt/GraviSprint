using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SavableVariable<I, T>
{
    public I Id { get => _id; }

    public T Value
    {
        get => _value;
        set
        {
            _value = value;

            if (IsValueChangeSavingEnable)
            {
                Save();
            }
        }
    }

    public bool IsValueChangeSavingEnable;

    private I _id;
    private T _value;


    public SavableVariable(I id, T value = default, bool loadImmediately = false, bool isValueChangeSavingEnable = true)
    {
        _id = id;
        _value = value;

        IsValueChangeSavingEnable = isValueChangeSavingEnable;

        if (loadImmediately)
        {
            Load();
        }
    }

    public void Save()
    {
        var json = JsonUtility.ToJson(this);
        Debug.Log(json);
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream fileStream = File.Create(Application.persistentDataPath + "save.dat");
        //formatter.Serialize(fileStream, this);
        //fileStream.Close();
    }

    public void Load()
    {
        //if (!File.Exists(Application.persistentDataPath + "save.dat")) return;

        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream fileStream = File.Open(Application.persistentDataPath + "save.dat", FileMode.Open);

        //if (fileStream.Length == 0)
        //{
        //    fileStream.Close();
        //    return;
        //}

        //var sav = (SavableVariable<I, T>)formatter.Deserialize(fileStream);

        //_id = sav.Id;
        //_value = sav.Value;

        //fileStream.Close();
    }
}
