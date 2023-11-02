using System;

namespace RockVoyage
{
    public class SceneEvents
    {
        public static Action OnCountdownEnded;
        public static Action OnConcertEnded;
        public static Action OnSongChosen;
        public static Action<float> OnWrongNotePlayed;
    }
}