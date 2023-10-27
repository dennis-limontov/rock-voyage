using System;

namespace RockVoyage
{
    public class SceneEvents
    {
        public static Action OnCountdownEnded;
        public static Action<float> OnWrongNotePlayed;
        public static Action OnConcertEnded;
    }
}