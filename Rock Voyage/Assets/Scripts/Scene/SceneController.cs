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
        private Statistics _statisticsCanvas;

        private float _perfomanceQuality = 1f;

        private void Start()
        {
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
        }

        private void ConcertEndedHandler()
        {
            _keysCanvas.SetActive(false);
            _statisticsCanvas.gameObject.SetActive(true);
            _statisticsCanvas.FillAllTexts(_perfomanceQuality, 1f, 300);
        }

        private void CountdownEndedHandler()
        {
            _music.Play();
        }

        private void WrongNotePlayedHandler(float penalty)
        {
            _perfomanceQuality -= penalty;
        }

        private void OnDestroy()
        {
            SceneEvents.OnWrongNotePlayed -= WrongNotePlayedHandler;
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
            SceneEvents.OnConcertEnded -= ConcertEndedHandler;
        }
    }
}