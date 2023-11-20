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

        [JsonProperty]
        private bool _isMapPurchased;
        [JsonIgnore]
        public bool IsMapPurchased
        {
            get => _isMapPurchased;
            set => _isMapPurchased = value;
        }

        [JsonProperty]
        private bool _isNewspaperPurchased;
        [JsonIgnore]
        public bool IsNewspaperPurchased
        {
            get => _isNewspaperPurchased;
            set => _isNewspaperPurchased = value;
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
            LoadSaveManager.loadSaveList.Add(this);
        }

        public void Load(string loadData)
        {
            MapInfo mapInfo = JsonConvert.DeserializeObject<MapInfo>(loadData);
            IsMapPurchased = mapInfo.IsMapPurchased;
            IsNewspaperPurchased = mapInfo.IsNewspaperPurchased;
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}