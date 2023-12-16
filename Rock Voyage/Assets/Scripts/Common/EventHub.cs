using System;

namespace RockVoyage
{
    public static class EventHub
    {
        public static Action<GameAttributes, object, object> OnValueChanged;

        static EventHub()
        {
            MapEvents.OnClockDateChanged += EventHandler<DateTime>(GameAttributes.Time);
            MapEvents.OnFameChanged += EventHandler<float>(GameAttributes.Fame);
            MapEvents.OnMoneyChanged += EventHandler<int>(GameAttributes.Money);
            SceneEvents.OnPerfomanceQualityChanged += EventHandler<float>(GameAttributes.PerfomanceQuality);
        }

        private static Action<T, T> EventHandler<T>(GameAttributes attribute)
        {
            return (T oldValue, T newValue) => OnValueChanged?.Invoke(attribute, oldValue, newValue);
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
        RecordCost = 16,
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
        CocktailName = 17,
    }
}