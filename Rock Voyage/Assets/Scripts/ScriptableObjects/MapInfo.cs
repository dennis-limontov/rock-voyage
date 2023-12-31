﻿using Newtonsoft.Json;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MapInfo")]
    public class MapInfo : ScriptableObject, ILoadSave
    {
        [SerializeField]
        private string _mapName;
        public string MapName => _mapName;

        private bool _isMapPurchased;
        public bool IsMapPurchased
        {
            get => _isMapPurchased;
            set
            {
                _isMapPurchased = value;
                MapEvents.OnMapBought?.Invoke();
            }
        }

        private bool _isNewspaperPurchased;
        public bool IsNewspaperPurchased
        {
            get => _isNewspaperPurchased;
            set
            {
                _isNewspaperPurchased = value;
                MapEvents.OnNewspaperBought?.Invoke();
            }
        }

        public string Name => name;

        private (bool IsMapPurchased, bool IsNewspaperPurchased) SerializableTuple
        {
            get => (_isMapPurchased, _isNewspaperPurchased);
            set
            {
                (_isMapPurchased, _isNewspaperPurchased) = value;
            }
        }

        [SerializeField]
        private GameObject _mapObjects;
        public GameObject MapObjects
        {
            get => _mapObjects;
            set => _mapObjects = value;
        }

        private void Awake()
        {
            LoadSaveManager.Add(Name, this);
        }

        private void OnDestroy()
        {
            LoadSaveManager.Remove(Name);
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