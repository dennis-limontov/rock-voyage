using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace JsonHelpers
{
    public class ReusableDictionaryConverter<K, V> : JsonConverter<IDictionary<K, V>>
    {
        public override bool CanWrite => false;

        public override IDictionary<K, V> ReadJson(JsonReader reader, Type objectType, IDictionary<K, V> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            IDictionary<K, V> ret = hasExistingValue ? existingValue : new Dictionary<K, V>();

            foreach (var kv in JObject.Load(reader))
            {
                K key = JsonConvert.DeserializeObject<K>($"\"{kv.Key}\"");
                V value;
                if (ret.TryGetValue(key, out value))
                {
                    serializer.Populate(kv.Value.CreateReader(), value);
                }
                else
                {
                    value = serializer.Deserialize<V>(reader);
                    ret.Add(key, value);
                }
            }
            return ret;
        }

        public override void WriteJson(JsonWriter writer, IDictionary<K, V> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
