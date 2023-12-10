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
        // Map scene
        Energy = 0,
        Fame = 1,
        Money = 2,
        Time = 3,
        // Scene scene
        CrowdHappiness = 4,
        MoneyProfit = 5,
        PerfomanceQuality = 6,
        PlayOnSceneAvailableDate = 7,
        // Pro Studio scene
        RecordAvailableDate = 8,
        // Street Music scene
        StreetMusicAvailableDate = 9,
        // Bar scene
        BarVisitors = 14, // 10
        BarBetVisitors = 15, // 11
        BeerGoal = 10, // 12
        BeerSteps = 11, // 13
        BeerPressure = 12, // 14
        BeerCurrentVolume = 13, // 15
    }
}