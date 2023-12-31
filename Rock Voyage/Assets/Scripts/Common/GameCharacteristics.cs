﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RockVoyage
{
    using static Constants.Scenes;

    public class GameCharacteristics : ILoadSave
    {
        public static GameCharacteristics Instance { get; } = new GameCharacteristics();

        public string Name => nameof(GameCharacteristics);

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

        private int _money = Constants.MONEY_AT_START;
        public static int Money
        {
            get => Instance._money;
            set
            {
                var ourMoney = Instance._money;
                Instance._money = value;
                MapEvents.OnMoneyChanged?.Invoke(ourMoney, value);
            }
        }

        private float _fame;
        public static float Fame
        {
            get => Instance._fame;
            set
            {
                var ourFame = Instance._fame;
                Instance._fame = value;
                MapEvents.OnFameChanged?.Invoke(ourFame, value);
            }
        }

        private DateTime _playOnSceneAvailableDate = DateTime.UnixEpoch;
        public static DateTime PlayOnSceneAvailableDate
        {
            get => Instance._playOnSceneAvailableDate;
            set
            {
                Instance._playOnSceneAvailableDate = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.PlayOnSceneAvailableDate,
                    DateTime.UnixEpoch, value);
            }
        }

        private DateTime _recordAvailableDate = DateTime.UnixEpoch;
        public static DateTime RecordAvailableDate
        {
            get => Instance._recordAvailableDate;
            set
            {
                Instance._recordAvailableDate = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.RecordAvailableDate,
                    DateTime.UnixEpoch, value);
            }
        }

        public List<PlayerCharacteristics> players
            = new List<PlayerCharacteristics>(Constants.PLAYERS_MAX);
        public static PlayerCharacteristics CurrentPlayer => Instance.players[0];

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

        private List<string> _availableSongs = new List<string>();
        public static List<string> AvailableSongs => Instance._availableSongs;

        private bool _isEnergyDrinkUsed;
        public static bool IsEnergyDrinkUsed
        {
            get => Instance._isEnergyDrinkUsed;
            set => Instance._isEnergyDrinkUsed = value;
        }

        private (DateTime ClockDate, int Money, float Fame, DateTime PlayOnSceneAvailableDate,
            DateTime RecordAvailableDate, List<PlayerCharacteristics> Players, string HostelInfoName,
            string MapInfoName, List<string> AvailableSongs, bool IsEnergyDrinkUsed)
            SerializableTuple
        {
            get => (ClockDate, Money, Fame, PlayOnSceneAvailableDate, RecordAvailableDate,
                players, HostelInfo.Name, MapInfo.Name, AvailableSongs, IsEnergyDrinkUsed);
            set
            {
                ClockDate = value.ClockDate;
                Money = value.Money;
                Fame = value.Fame;
                PlayOnSceneAvailableDate = value.PlayOnSceneAvailableDate;
                RecordAvailableDate = value.RecordAvailableDate;
                players = value.Players;
                ILoadSave hostelSO = null, mapSO;
                if (value.HostelInfoName != null)
                {
                    LoadSaveManager.loadSaveList.TryGetValue(value.HostelInfoName, out hostelSO);
                }
                HostelInfo = (HostelInfo)hostelSO;
                LoadSaveManager.loadSaveList.TryGetValue(value.MapInfoName, out mapSO);
                MapInfo = (MapInfo)mapSO;
                _availableSongs = value.AvailableSongs;
                _isEnergyDrinkUsed = value.IsEnergyDrinkUsed;
            }
        }

        GameCharacteristics()
        {
            ((ILoadSave)this).Awake();
        }

        public void Load(string loadData)
        {
            SerializableTuple = JsonConvert.DeserializeObject<(DateTime, int, float,
                DateTime, DateTime, List<PlayerCharacteristics>, string, string,
                List<string>, bool)>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(SerializableTuple);
        }

        public static void Reset()
        {
            Instance.SerializableTuple = (DateTime.UnixEpoch, Constants.MONEY_AT_START,
                0f, DateTime.UnixEpoch, DateTime.UnixEpoch,
                new List<PlayerCharacteristics>(Constants.PLAYERS_MAX),
                null, START_CITY, new List<string>(), false);
        }
    }
}