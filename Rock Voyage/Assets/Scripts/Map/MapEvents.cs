using System;

namespace RockVoyage
{
    public class MapEvents
    {
        public static Action<DateTime, DateTime> OnClockDateChanged;
        public static Action<int, int> OnMoneyChanged;
    }
}