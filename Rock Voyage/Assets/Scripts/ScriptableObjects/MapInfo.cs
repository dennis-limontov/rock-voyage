using Newtonsoft.Json;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MapInfo")]
    public class MapInfo : ScriptableObject, ILoadSave
    {
        [SerializeField]
        private string _mapName;
        [JsonIgnore]
        public string MapName => _mapName;

        [JsonIgnore]
        private bool _isMapPurchased;
        [JsonIgnore]
        public bool IsMapPurchased
        {
            get => _isMapPurchased;
            set => _isMapPurchased = value;
        }

        [JsonIgnore]
        private bool _isNewspaperPurchased;
        [JsonIgnore]
        public bool IsNewspaperPurchased
        {
            get => _isNewspaperPurchased;
            set => _isNewspaperPurchased = value;
        }

        public string Name => name;

        [JsonProperty]
        private (bool IsMapPurchased, bool IsNewspaperPurchased) SerializableTuple
        {
            get => (_isMapPurchased, _isNewspaperPurchased);
            set
            {
                (_isMapPurchased, _isNewspaperPurchased) = value;
            }
        }

        [JsonIgnore]
        [SerializeField]
        private GameObject _mapObjects;
        [JsonIgnore]
        public GameObject MapObjects
        {
            get => _mapObjects;
            set => _mapObjects = value;
        }

        private void Awake()
        {
            LoadSaveManager.loadSaveList.TryAdd(Name, this);
        }

        private void OnDestroy()
        {
            LoadSaveManager.loadSaveList.Remove(Name);
        }

        public void Load(string loadData)
        {
            SerializableTuple = JsonConvert.DeserializeObject<(bool, bool)>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(SerializableTuple);
        }
    }
}