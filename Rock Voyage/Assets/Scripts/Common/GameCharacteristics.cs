using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RockVoyage
{
    public class GameCharacteristics : ILoadSave
    {
        public static GameCharacteristics Instance { get; private set; } = new GameCharacteristics();

        [JsonProperty]
        private DateTime _clockDate = DateTime.UnixEpoch;
        public static DateTime ClockDate
        { 
            get => Instance._clockDate;
            set
            {
                MapEvents.OnClockDateChanged?.Invoke(Instance._clockDate, value);
                Instance._clockDate = value;
            }
        }

        [JsonIgnore]
        private MapInfo _mapInfo;
        [JsonIgnore]
        public static MapInfo MapInfo
        {
            get => Instance._mapInfo;
            set => Instance._mapInfo = value;
        }

        [JsonProperty]
        private int _money = Constants.MONEY_AT_START;
        public static int Money
        {
            get => Instance._money;
            set
            {
                MapEvents.OnMoneyChanged?.Invoke(Instance._money, value);
                Instance._money = value;
            }
        }

        [JsonProperty]
        private float _fame;
        public static float Fame
        {
            get => Instance._fame;
            set => Instance._fame = value;
        }

        [JsonProperty]
        private DateTime _recordAvailableDate = DateTime.UnixEpoch;
        public static DateTime RecordAvailableDate
        {
            get => Instance._recordAvailableDate;
            set
            {
                Instance._recordAvailableDate = value;
            }
        }

        [JsonProperty]
        private List<SongInfo> _availableSongs = new List<SongInfo>();
        public static List<SongInfo> AvailableSongs => Instance._availableSongs;

        public List<PlayerCharacteristics> players
            = new List<PlayerCharacteristics>(Constants.PLAYERS_MAX);
        public static PlayerCharacteristics CurrentPlayer => Instance.players[0];

        GameCharacteristics()
        {
            ((ILoadSave)this).Awake();
        }

        public void Load(string loadData)
        {
            Instance = JsonConvert.DeserializeObject<GameCharacteristics>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}