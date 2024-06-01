using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

namespace JsonHelpers
{
    public class EmptyObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return Type.GetTypeCode(objectType) == TypeCode.Object;
        }

        public override bool CanRead => false;

        public override bool CanWrite => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader);
        }

        private static bool CheckEmpty(object value, JsonObjectContract contract)
        {
            if (value == default) return true;
            if (contract == null) return true;
            var members = contract.Properties;
            return !members.Any(x => !x.Ignored && x.Readable
            && (x.ShouldSerialize?.Invoke(value) != false)
            && (x.GetIsSpecified?.Invoke(value)) != false);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            bool isEmpty = CheckEmpty(value, serializer.ContractResolver
                .ResolveContract(value.GetType()) as JsonObjectContract);

            serializer.Serialize(writer, isEmpty? null : value);
        }
    }
}
