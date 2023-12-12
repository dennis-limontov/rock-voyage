using System;

namespace RockVoyage
{
    public static class MapEvents
    {
        public static Action<DateTime, DateTime> OnClockDateChanged;
        public static Action OnLowEnergy;
        public static Action<float, float> OnFameChanged;
        public static Action<HouseInfo> OnSceneLoaded;
        public static Action<HouseInfo> OnScenePreUnloaded;
        public static Action OnMapBought;
        public static Action<int, int> OnMoneyChanged;
        public static Action OnNewspaperBought;
    }
}