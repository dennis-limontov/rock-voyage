using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace RockVoyage
{
    [Serializable, DataContract]
    public class BarInfo : HouseInfo
    {
        public const float ENERGY_DRINK_EFFECT = 0.5f;
        public static readonly TimeSpan QUEST_TIME = new TimeSpan(3, 0, 0);

        [field: SerializeField]
        public int Capacity { get; private set; }

        [field: SerializeField]
        public int EnergyDrinkCost { get; private set; }
    }
} 