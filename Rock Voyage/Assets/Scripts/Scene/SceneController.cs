using UnityEngine;

namespace RockVoyage
{
    public class SceneController : UIActiveOneChild
    {
        [SerializeField]
        private CloseButton _closeButton;

        [SerializeField]
        private UIBase _countdown;

        private float _perfomanceQuality = 1f;
        private float PerfomanceQuality
        {
            get => _perfomanceQuality;
            set
            {
                _perfomanceQuality = value;
                SceneEvents.OnPerfomanceQualityChanged?.Invoke(_perfomanceQuality);
            }
        }

        private void ConcertEndedHandler()
        {
            _closeButton.transform.parent.gameObject.SetActive(true);
            GoToNext();
            if (CurrentElement is Statistics statistics)
            {
                statistics.FillAllTexts(_perfomanceQuality, 1f, 300);
            }
        }

        private void SongChosenHandler(SongInfo currentSong)
        {
            PerfomanceQuality = 1f;
            _closeButton.transform.parent.gameObject.SetActive(false);
            GoTo(_countdown);
        }

        private void WrongNotePlayedHandler(float penalty)
        {
            PerfomanceQuality -= penalty;
        }

        private void OnDestroy()
        {
            SceneEvents.OnWrongNotePlayed -= WrongNotePlayedHandler;
            SceneEvents.OnSongChosen -= SongChosenHandler;
            SceneEvents.OnCountdownEnded -= GoToNext;
            SceneEvents.OnConcertEnded -= ConcertEndedHandler;
        }

        public override void Init(UIBaseParent parent)
        {
            base.Init(parent);
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnCountdownEnded += GoToNext;
            SceneEvents.OnSongChosen += SongChosenHandler;
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
        }
    }
}