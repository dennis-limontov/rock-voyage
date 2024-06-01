using JsonHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace RockVoyage
{
    using static Constants;

    [Serializable, DataContract]
    public class GameCharacteristics : ILoadSaveRoot
    {
        public static readonly GameCharacteristics Instance = new GameCharacteristics();

        public string Name => nameof(GameCharacteristics);

        private DateTime _clockDate = DateTime.UnixEpoch;
        [DataMember]
        private DateTime clockDate
        {
            get => _clockDate;
            set
            {
                var ourTime = clockDate;
                _clockDate = value;
                MapEvents.OnClockDateChanged?.Invoke(ourTime, value);
            }
        }
        public static DateTime ClockDate
        {
            get => Instance.clockDate;
            set => Instance.clockDate = value;
        }

        private int _money = MONEY_AT_START;
        [DataMember]
        private int money
        {
            get => _money;
            set
            {
                var ourMoney = _money;
                _money = value;
                MapEvents.OnMoneyChanged?.Invoke(ourMoney, value);
            }
        }
        public static int Money
        {
            get => Instance.money;
            set => Instance.money = value;
        }

        private float _fame;
        [DataMember]
        private float fame
        {
            get => Instance._fame;
            set
            {
                var ourFame = _fame;
                _fame = value;
                MapEvents.OnFameChanged?.Invoke(ourFame, value);
            }
        }
        public static float Fame
        {
            get => Instance.fame;
            set => Instance.fame = value;
        }

        private DateTime _playOnSceneAvailableDate = DateTime.UnixEpoch;
        [DataMember]
        [SerializeIfGreaterThanCurrent]
        private DateTime playOnSceneAvailableDate
        {
            get => _playOnSceneAvailableDate;
            set
            {
                _playOnSceneAvailableDate = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.PlayOnSceneAvailableDate,
                    DateTime.UnixEpoch, value);
            }
        }
        public static DateTime PlayOnSceneAvailableDate
        {
            get => Instance.playOnSceneAvailableDate;
            set => Instance.playOnSceneAvailableDate = value;
        }

        private DateTime _recordAvailableDate = DateTime.UnixEpoch;
        [DataMember]
        [SerializeIfGreaterThanCurrent]
        private DateTime recordAvailableDate
        {
            get => _recordAvailableDate;
            set
            {
                _recordAvailableDate = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.RecordAvailableDate,
                    DateTime.UnixEpoch, value);
            }
        }
        public static DateTime RecordAvailableDate
        {
            get => Instance.recordAvailableDate;
            set => Instance.recordAvailableDate = value;
        }

        private MapInfo _mapInfo;
        public static MapInfo MapInfo
        {
            get => Instance._mapInfo;
            set => Instance._mapInfo = value;
        }

        [DataMember]
        private SortedSet<string> _availableSongs = new SortedSet<string>();
        public static SortedSet<string> AvailableSongs => Instance._availableSongs;

        [DataMember]
        private bool _isEnergyDrinkUsed;
        public static bool IsEnergyDrinkUsed
        {
            get => Instance._isEnergyDrinkUsed;
            set => Instance._isEnergyDrinkUsed = value;
        }

        public void Reset()
        {
            ClockDate = DateTime.UnixEpoch;
            Money = MONEY_AT_START;
            Fame = 0f;
            PlayOnSceneAvailableDate = DateTime.UnixEpoch;
            RecordAvailableDate = DateTime.UnixEpoch;
            MapInfo = null;
            AvailableSongs.Clear();
            IsEnergyDrinkUsed = false;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Instance.AddLoadSaveable();
        }

        private GameCharacteristics() { }
    }
}