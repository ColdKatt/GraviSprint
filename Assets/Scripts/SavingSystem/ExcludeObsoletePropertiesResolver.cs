using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;

public class ExcludeObsoletePropertiesResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty prop = base.CreateProperty(member, memberSerialization);
        if (prop.AttributeProvider.GetAttributes(true).OfType<ObsoleteAttribute>().Any())
        {
            prop.ShouldSerialize = obj => false;
        }
        return prop;
    }
}
