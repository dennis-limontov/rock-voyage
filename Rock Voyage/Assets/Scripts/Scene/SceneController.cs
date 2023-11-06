using UnityEngine;

namespace RockVoyage
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _music;

        [SerializeField]
        private GameObject _keysCanvas;

        [SerializeField]
        private Canvas _statisticsCanvas;

        [SerializeField]
        private CloseButton _closeButton;

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

        private void Start()
        {
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
            SceneEvents.OnSongChosen += SongChosenHandler;
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
        }

        private void SongChosenHandler(SongInfo currentSong)
        {
            _music.clip = currentSong.MusicForGroup;
            PerfomanceQuality = 1f;
            _closeButton.transform.parent.gameObject.SetActive(false);
        }

        private void ConcertEndedHandler()
        {
            _keysCanvas.SetActive(false);
            _closeButton.transform.parent.gameObject.SetActive(true);
            _statisticsCanvas.gameObject.SetActive(true);
            if (_statisticsCanvas.TryGetComponent(out Statistics statistics))
            {
                statistics.FillAllTexts(_perfomanceQuality, 1f, 300);
            }
        }

        private void CountdownEndedHandler()
        {
            _keysCanvas.SetActive(true);
            _music.Play();
        }

        private void WrongNotePlayedHandler(float penalty)
        {
            PerfomanceQuality -= penalty;
        }

        private void OnDestroy()
        {
            SceneEvents.OnWrongNotePlayed -= WrongNotePlayedHandler;
            SceneEvents.OnSongChosen -= SongChosenHandler;
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
            SceneEvents.OnConcertEnded -= ConcertEndedHandler;
        }
    }
}