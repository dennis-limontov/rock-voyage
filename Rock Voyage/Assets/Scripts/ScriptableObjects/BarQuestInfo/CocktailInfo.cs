using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RockVoyage
{
    [Serializable, DataContract]
    public struct CocktailInfo
    {
        [DataMember(IsRequired = true)]
        public string Name { get; private set; }
        [DataMember(IsRequired = true)]
        public KeyValuePair<string, float>[] Ingredients { get; private set; }
    }
}
