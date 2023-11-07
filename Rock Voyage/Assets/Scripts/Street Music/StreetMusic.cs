using System.Collections;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class StreetMusic : MonoBehaviour
    {
        [SerializeField]
        private SongsList _songsList;

        [SerializeField]
        private StreetMusicInfo _streetMusicInfo;

        [SerializeField]
        private GameObject _musicAction;

        [SerializeField]
        private GameObject _variants1;

        [SerializeField]
        private GameObject _variants2;

        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private TextMeshProUGUI _nextAvailableTimeText;

        [SerializeField]
        private TextMeshProUGUI _failRememberText;

        [SerializeField]
        private TextMeshProUGUI _successRememberText;

        [SerializeField]
        private TextMeshProUGUI _fulfilledKnowledgeText;

        [SerializeField]
        private EarnedMoney _earnedMoney;

        private void OnDestroy()
        {
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
        }

        private void Start()
        {
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
            _playButton.gameObject.SetActive(_streetMusicInfo.IsAvailable);
            _nextAvailableTimeText.transform.parent.gameObject.SetActive(!_streetMusicInfo.IsAvailable);
            _nextAvailableTimeText.text = _streetMusicInfo.PlayAgainTime
                .ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
        }

        private void CountdownEndedHandler()
        {
            _earnedMoney.StartCoroutine(PlayLittleSongPart());
        }

        public void OnRememberClicked()
        {
            _variants1.SetActive(false);
            _variants2.SetActive(true);
            if (GameCharacteristics.AvailableSongs.Count < _songsList.Length)
            {
                var rememberChance = Random.Range(0f, 1f);
                if (rememberChance <= Constants.REMEMBER_CHANCE)
                {
                    SongInfo[] unknownSongs = _songsList
                        .Except(GameCharacteristics.AvailableSongs).ToArray();
                    int randomIndex = Random.Range(0, unknownSongs.Length);
                    GameCharacteristics.AvailableSongs.Add(unknownSongs[randomIndex]);
                    _failRememberText.gameObject.SetActive(false);
                    _fulfilledKnowledgeText.gameObject.SetActive(false);
                    _successRememberText.gameObject.SetActive(true);
                }
                else
                {
                    _successRememberText.gameObject.SetActive(false);
                    _fulfilledKnowledgeText.gameObject.SetActive(false);
                    _failRememberText.gameObject.SetActive(true);
                }
            }
            else
            {
                _successRememberText.gameObject.SetActive(false);
                _failRememberText.gameObject.SetActive(false);
                _fulfilledKnowledgeText.gameObject.SetActive(true);
            }
        }

        public void OnPlayClicked()
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            _musicAction.SetActive(true);
            _earnedMoney.gameObject.SetActive(true);
            _streetMusicInfo.PlayAgainTime = GameCharacteristics.ClockDate.AddDays(1);
            _playButton.gameObject.SetActive(false);
            _nextAvailableTimeText.text = _streetMusicInfo.PlayAgainTime
                .ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
        }

        private IEnumerator PlayLittleSongPart()
        {
            yield return new WaitForSeconds(30f);

            _nextAvailableTimeText.transform.parent.gameObject.SetActive(!_streetMusicInfo.IsAvailable);
            SceneEvents.OnConcertEnded?.Invoke();
            _earnedMoney.gameObject.SetActive(false);
        }

        public void OnBackClicked()
        {
            _variants2.SetActive(false);
            _variants1.SetActive(true);
        }
    }
}