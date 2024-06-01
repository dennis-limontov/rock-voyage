using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using System;

namespace JsonHelpers
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        private static readonly EmptyObjectConverter emptyObjectConverter
            = new EmptyObjectConverter();

        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);
            var genericArguments = objectType.GenericTypeArguments;
            if (genericArguments.Length == 2)
            {
                contract.Converter = (JsonConverter)Activator.CreateInstance(
                    typeof(ReusableDictionaryConverter<,>)
                    .MakeGenericType(objectType.GenericTypeArguments));
                if (emptyObjectConverter.CanConvert(objectType.GenericTypeArguments[1]))
                {
                    contract.ItemConverter = emptyObjectConverter;
                }
            }
            return contract;
        }
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
