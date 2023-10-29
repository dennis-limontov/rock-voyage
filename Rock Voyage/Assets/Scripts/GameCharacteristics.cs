using System;

namespace RockVoyage
{
    public static class GameCharacteristics
    {
        private static DateTime _clockDate = DateTime.UnixEpoch;
        public static DateTime ClockDate
        { 
            get => _clockDate;
            set => _clockDate = value;
        }

        private static MapInfo _mapInfo;
        public static MapInfo MapInfo
        {
            get => _mapInfo;
            set => _mapInfo = value;
        }
    }
}