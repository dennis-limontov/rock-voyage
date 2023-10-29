using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Maps/MapInfo")]
    public class MapInfo : ScriptableObject
    {
        [SerializeField]
        private string _mapName;
        public string MapName => _mapName;

        private bool _isMapPurchased;
        public bool IsMapPurchased
        {
            get => _isMapPurchased;
            set => _isMapPurchased = value;
        }

        private bool _isNewspaperPurchased;
        public bool IsNewspaperPurchased
        {
            get => _isNewspaperPurchased;
            set => _isNewspaperPurchased = value;
        }
    }
}