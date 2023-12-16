using System;

namespace RockVoyage
{
    public static class BarEvents
    {
        public static Action OnBeerQuestEnded;
        public static Action<bool> OnQuestEndedWithResult;
        public static Action<int> OnBeerQuestStepMade;
    }
}