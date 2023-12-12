using System;

namespace RockVoyage
{
    public static class SceneEvents
    {
        public static Action OnCountdownEnded;
        public static Action OnConcertEnded;
        public static Action<char, char> OnCurrentNoteChanged;
        public static Action<float, float> OnPerfomanceQualityChanged;
        public static Action<SongInfo> OnSongChosen;
        public static Action OnRightNotePlayed;
        public static Action OnWrongNotePlayed;
    }
}