using System;

namespace RockVoyage
{
    public static class BarEvents
    {
        public static Action OnBeerQuestEnded;
        public static Action<bool> OnBeerQuestEndedWithResult;
        public static Action<int> OnBeerQuestStepMade;
    }
}