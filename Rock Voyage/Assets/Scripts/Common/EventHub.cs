using System;

namespace RockVoyage
{
    public static class EventHub
    {
        public static Action<GameAttributes, object, object> OnValueChanged;

        public static void Initialize()
        {
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
            MapEvents.OnFameChanged += FameChangedHandler;
            MapEvents.OnMoneyChanged += MoneyChangedHandler;
            SceneEvents.OnPerfomanceQualityChanged += PerfomanceQualityChangedHandler;
        }

        private static void ClockDateChangedHandler(DateTime arg1, DateTime arg2)
        {
            OnValueChanged?.Invoke(GameAttributes.Time, arg1, arg2);
        }

        private static void FameChangedHandler(float arg1, float arg2)
        {
            OnValueChanged?.Invoke(GameAttributes.Fame, arg1, arg2);
        }

        private static void MoneyChangedHandler(int arg1, int arg2)
        {
            OnValueChanged?.Invoke(GameAttributes.Money, arg1, arg2);
        }

        private static void PerfomanceQualityChangedHandler(float obj)
        {
            OnValueChanged?.Invoke(GameAttributes.PerfomanceQuality, 0f, obj);
        }
    }

    public enum GameAttributes
    {
        Energy = 0,
        Fame = 1,
        Money = 2,
        Time = 3,

        CrowdHappiness = 4,
        MoneyProfit = 5,
        PerfomanceQuality = 6,

        PlayOnSceneAvailableDate = 7,
        RecordAvailableDate = 8,
        StreetMusicAvailableDate = 9
    }
}