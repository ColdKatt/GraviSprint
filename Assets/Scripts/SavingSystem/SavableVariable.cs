using Newtonsoft.Json;

public class SavableVariable<T>
{
    public string Id { get => _id; }

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

    private string _id;

    private T _value;

    private string _json;

    public SavableVariable(string id, T value = default, bool loadImmediately = false, bool isValueChangeSavingEnable = true)
    {
        _id = id;
        _value = value;

        IsValueChangeSavingEnable = isValueChangeSavingEnable;

        _json = JsonHandler.GetJsonById(Id);

        if (loadImmediately)
        {
            Load();
        }
    }

    public void Save()
    {
        var serializeSettings = new JsonSerializerSettings
        {
            ContractResolver = new ExcludeObsoletePropertiesResolver(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        _json = JsonConvert.SerializeObject(_value, serializeSettings);

        JsonHandler.SetJsonValueById(Id, _json);
    }

    public T Load()
    {
        if (string.IsNullOrEmpty(_json)) return _value;

        _value = JsonConvert.DeserializeObject<T>(_json);

        return _value;
    }
}
