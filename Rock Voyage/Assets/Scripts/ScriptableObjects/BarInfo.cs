using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BarInfo")]
    public class BarInfo : HouseInfo
    {
        [SerializeField]
        private string _barName;
        public string BarName => _barName;

        [SerializeField]
        private int _energyDrinkCost;
        public int EnergyDrinkCost => _energyDrinkCost;
    }
} 