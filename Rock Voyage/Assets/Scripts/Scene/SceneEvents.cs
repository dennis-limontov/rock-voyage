using System;

namespace RockVoyage
{
    public class SceneEvents
    {
        public static Action OnCountdownEnded;
        public static Action OnConcertEnded;
        public static Action<char, char> OnCurrentNoteChanged;
        public static Action<float> OnPerfomanceQualityChanged;
        public static Action<SongInfo> OnSongChosen;
        public static Action OnRightNotePlayed;
        public static Action<float> OnWrongNotePlayed;
    }
}