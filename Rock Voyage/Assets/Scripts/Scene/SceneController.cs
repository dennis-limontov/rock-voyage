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

        public override void Init(UIBaseParent parent)
        {
            base.Init(parent);
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnCountdownEnded += GoToNext;
            SceneEvents.OnSongChosen += SongChosenHandler;
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
        }

        private void ConcertEndedHandler()
        {
            _closeButton.transform.parent.gameObject.SetActive(true);
            if (_currentIndex + 1 < children.Length)
            {
                GoToNext();
                EventHub.OnValueChanged?.Invoke(GameAttributes.CrowdHappiness, 0f, 1f);
                EventHub.OnValueChanged?.Invoke(GameAttributes.MoneyProfit, 0, 300);
            }
            else
            {
                ((UIActiveOneChild)GetController()).GoToFirst();
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
    }
}