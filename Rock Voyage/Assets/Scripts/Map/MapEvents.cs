using System;

namespace RockVoyage
{
    public class MapEvents
    {
        public static Action<DateTime, DateTime> OnClockDateChanged;
        public static Action OnMapBought;
        public static Action<int, int> OnMoneyChanged;
        public static Action OnNewspaperBought;
    }
}