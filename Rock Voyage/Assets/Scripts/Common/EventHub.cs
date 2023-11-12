using System;

namespace RockVoyage
{
    public static class EventHub
    {
        public static Action<GameAttributes, object, object> OnValueChanged;

        public static void Initialize()
        {
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
            MapEvents.OnMoneyChanged += MoneyChangedHandler;
        }

        private static void ClockDateChangedHandler(DateTime arg1, DateTime arg2)
        {
            OnValueChanged?.Invoke(GameAttributes.Time, arg1, arg2);
        }

        private static void MoneyChangedHandler(int arg1, int arg2)
        {
            OnValueChanged?.Invoke(GameAttributes.Money, arg1, arg2);
        }
    }

    public enum GameAttributes
    {
        Energy,
        Fame,
        Money,
        PerfomanceQuality,
        Time
    }
}