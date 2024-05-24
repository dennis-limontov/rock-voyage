using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using System;

namespace JsonHelpers
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            var attr = property.AttributeProvider.GetAttributes(typeof(SerializeIfGreaterThanCurrentAttribute), true).Count;
            if (attr > 0 && property.PropertyType == typeof(DateTime))
            {
                property.ShouldSerialize = instance =>
                {
                    DateTime value = (DateTime)property.ValueProvider.GetValue(instance);
                    return value > RockVoyage.GameCharacteristics.ClockDate;
                };
            }

            return property;
        }
    }
}
