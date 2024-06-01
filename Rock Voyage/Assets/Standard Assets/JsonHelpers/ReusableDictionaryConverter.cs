using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonHelpers
{
    public class ReusableDictionaryConverter<K, V> : JsonConverter<IDictionary<K, V>>
    {
        public override bool CanWrite => false;

        public override IDictionary<K, V> ReadJson(JsonReader reader, Type objectType, IDictionary<K, V> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObj = serializer.Deserialize<JObject>(reader);
            IDictionary<K, V> result = hasExistingValue ? existingValue : (IDictionary<K, V>)Activator.CreateInstance(objectType, jObj.Count);

            K key;
            V value;
            foreach (var kv in jObj)
            {
                if (kv.Value.Type == JTokenType.Null) continue;
                using (var sr = new StringReader($"\"{kv.Key}\""))
                using (var keyReader = new JsonTextReader(sr))
                {
                    key = serializer.Deserialize<K>(keyReader);
                }
                using (var valueReader = kv.Value.CreateReader())
                {
                    if (result.TryGetValue(key, out value))
                    {
                        serializer.Populate(valueReader, value);
                    }
                    else
                    {
                        value = serializer.Deserialize<V>(valueReader);
                        result.Add(key, value);
                    }
                }
            }
            return result;
        }

        public override void WriteJson(JsonWriter writer, IDictionary<K, V> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
