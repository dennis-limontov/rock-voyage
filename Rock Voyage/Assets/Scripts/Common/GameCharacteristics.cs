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

        public static List<PlayerCharacteristics> players
            = new List<PlayerCharacteristics>(Constants.PLAYERS_MAX);
    }
}