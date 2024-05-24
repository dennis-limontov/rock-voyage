using System;
using System.Runtime.Serialization;

namespace RockVoyage
{
    [Serializable, DataContract]
    public struct IngredientInfo
    {
        [DataMember(IsRequired = true)]
        public string Name { get; private set; }
        [DataMember(IsRequired = true)]
        public float[] Doses { get; private set; }
        [DataMember(IsRequired = true)]
        public string Measure { get; private set; }
    }
}
