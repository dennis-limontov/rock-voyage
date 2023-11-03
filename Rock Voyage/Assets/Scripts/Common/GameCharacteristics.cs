using System;
using System.Collections.Generic;

namespace RockVoyage
{
    public static class GameCharacteristics
    {
        private static DateTime _clockDate = DateTime.UnixEpoch;
        public static DateTime ClockDate
        { 
            get => _clockDate;
            set
            {
                MapEvents.OnClockDateChanged?.Invoke(_clockDate, value);
                _clockDate = value;
            }
        }

        private static MapInfo _mapInfo;
        public static MapInfo MapInfo
        {
            get => _mapInfo;
            set => _mapInfo = value;
        }

        private static int _money = Constants.MONEY_AT_START;
        public static int Money
        {
            get => _money;
            set
            {
                MapEvents.OnMoneyChanged?.Invoke(_money, value);
                _money = value;
            }
        }

        private static float _fame;
        public static float Fame
        {
            get => _fame;
            set => _fame = value;
        }

        private static DateTime _recordAvailableDate = DateTime.UnixEpoch;
        public static DateTime RecordAvailableDate
        {
            get => _recordAvailableDate;
            set
            {
                _recordAvailableDate = value;
            }
        }

        public static List<PlayerCharacteristics> players
            = new List<PlayerCharacteristics>(Constants.PLAYERS_MAX);
        public static PlayerCharacteristics CurrentPlayer => players[0];
    }
}