using JsonHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MapInfo")]
    [Serializable, DataContract]
    public class MapInfo : ScriptableObject, ILoadSaveRoot
    {
        public string Name => SceneName;

        [field: SerializeField]
        public string SceneName { get; private set; }

        private bool _isMapPurchased;
        [DataMember]
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
        [DataMember]
        public bool IsNewspaperPurchased
        {
            get => _isNewspaperPurchased;
            set
            {
                _isNewspaperPurchased = value;
                MapEvents.OnNewspaperBought?.Invoke();
            }
        }

        [DataMember, JsonConverter(typeof(ReusableDictionaryConverter<string, HouseInfo>))]
        public Dictionary<string, HouseInfo> Houses { get; private set; } = new Dictionary<string, HouseInfo>();

        public GameObject MapObjects { get; set; }

        public HostelInfo BookedHostel => (HostelInfo)Houses.Values
            .FirstOrDefault(house => (house as HostelInfo)?.IsBooked == true);

        public void Init()
        {
            ((ILoadSaveRoot)this).AddLoadSaveable();
        }

        public void Release()
        {
            ((ILoadSaveRoot)this).RemoveLoadSaveable();
            Houses.Clear();
            MapObjects = null;
        }
    }
}