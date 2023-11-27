using Newtonsoft.Json;
using System;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/StreetMusicInfo")]
    public class StreetMusicInfo : HouseInfo, ILoadSave
    {
        public bool IsAvailable => _playAgainTime <= GameCharacteristics.ClockDate;

        [JsonProperty]
        private DateTime _playAgainTime = DateTime.UnixEpoch;
        public DateTime PlayAgainTime
        {
            get => _playAgainTime;
            set => _playAgainTime = value;
        }

        public string Name => name;

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
            _playAgainTime = JsonConvert.DeserializeObject<DateTime>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(_playAgainTime);
        }
    }
}