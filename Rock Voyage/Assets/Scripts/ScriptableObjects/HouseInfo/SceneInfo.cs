using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace RockVoyage
{
    [Serializable, DataContract]
    public class SceneInfo : HouseInfo
    {
        public const float PROFIT_PERCENT = 0.1f;

        [field: SerializeField]
        public int FansCapacity { get; private set; }
    }
}