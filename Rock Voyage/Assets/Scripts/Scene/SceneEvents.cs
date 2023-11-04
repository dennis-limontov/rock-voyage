using System;

namespace RockVoyage
{
    public class SceneEvents
    {
        public static Action OnCountdownEnded;
        public static Action OnConcertEnded;
        public static Action<SongInfo> OnSongChosen;
        public static Action<float> OnWrongNotePlayed;
    }
}