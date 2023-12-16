using System;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/HouseInfo/BarInfo")]
    public class BarInfo : HouseInfo
    {
        public static readonly TimeSpan QUEST_TIME = new TimeSpan(3, 0, 0);

        [SerializeField]
        private string _barName;
        public string BarName => _barName;

        [SerializeField]
        private int _capacity;
        public int Capacity => _capacity;

        [SerializeField]
        private int _energyDrinkCost;
        public int EnergyDrinkCost => _energyDrinkCost;
    }
} 