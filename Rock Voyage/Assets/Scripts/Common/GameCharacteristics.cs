using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RockVoyage
{
    public class GameCharacteristics : ILoadSave
    {
        public static GameCharacteristics Instance { get; private set; } = new GameCharacteristics();

        public string Name => "GameCharacteristics";

        private DateTime _clockDate = DateTime.UnixEpoch;
        public static DateTime ClockDate
        { 
            get => Instance._clockDate;
            set
            {
                var ourTime = Instance._clockDate;
                Instance._clockDate = value;
                MapEvents.OnClockDateChanged?.Invoke(ourTime, value);
            }
        }

        private HostelInfo _hostelInfo;
        public static HostelInfo HostelInfo
        {
            get => Instance._hostelInfo;
            set => Instance._hostelInfo = value;
        }

        private MapInfo _mapInfo;
        public static MapInfo MapInfo
        {
            get => Instance._mapInfo;
            set => Instance._mapInfo = value;
        }

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

        private float _fame;
        public static float Fame
        {
            get => Instance._fame;
            set
            {
                MapEvents.OnFameChanged?.Invoke(Instance._fame, value);
                Instance._fame = value;
            }
        }

        private DateTime _playOnSceneAvailableDate = DateTime.UnixEpoch;
        public static DateTime PlayOnSceneAvailableDate
        {
            get => Instance._playOnSceneAvailableDate;
            set
            {
                Instance._playOnSceneAvailableDate = value;
            }
        }

        private DateTime _recordAvailableDate = DateTime.UnixEpoch;
        public static DateTime RecordAvailableDate
        {
            get => Instance._recordAvailableDate;
            set
            {
                Instance._recordAvailableDate = value;
            }
        }

        private List<SongInfo> _availableSongs = new List<SongInfo>();
        public static List<SongInfo> AvailableSongs => Instance._availableSongs;

        public List<PlayerCharacteristics> players
            = new List<PlayerCharacteristics>(Constants.PLAYERS_MAX);
        public static PlayerCharacteristics CurrentPlayer => Instance.players[0];

        private (DateTime ClockDate, int Money, float Fame, DateTime PlayOnSceneAvailableDate,
            DateTime RecordAvailableDate, List<PlayerCharacteristics> Players)
            SerializableTuple
        {
            get => (ClockDate, Money, Fame, PlayOnSceneAvailableDate, RecordAvailableDate, players);
            set
            {
                (ClockDate, Money, Fame, PlayOnSceneAvailableDate, RecordAvailableDate, players) = value;
            }
        }

        GameCharacteristics()
        {
            ((ILoadSave)this).Awake();
        }

        public void Load(string loadData)
        {
            SerializableTuple = JsonConvert.DeserializeObject<(DateTime, int, float,
                DateTime, DateTime, List<PlayerCharacteristics>)>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(SerializableTuple);
        }
    }
}