using System;

namespace RockVoyage
{
    public class Events
    {
        public static Action OnCountdownEnded;
        public static Action<float> OnWrongNotePlayed;
    }
}