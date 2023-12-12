using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class Keys : UIBase
    {
        [SerializeField]
        private GameObject _keyPrefab;

        [SerializeField]
        private AudioSource _music;

        [SerializeField]
        private Image _square;

        private SongInfo _currentSong;

        private float _keysSpeed = 0f;

        private RectTransform _keysTransform;

        private IEnumerator _keysCoroutine;

        public override void Dispose()
        {
            SceneEvents.OnSongChosen -= SongChosenHandler;
            base.Dispose();
        }

        public override void Enter()
        {
            base.Enter();
            SceneEvents.OnRightNotePlayed += RightNotePlayedHandler;
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
            _music.Play();
            // _keysSpeed = _keysTransform.sizeDelta.x / _bsParanoidSO.MusicForGroup.length; // 90400/164 = 22600/41
            _keysSpeed = _keyPrefab.GetComponent<RectTransform>().sizeDelta.x
                * _currentSong.SongKeys.Length / _currentSong.MusicForGroup.length;
            _keysCoroutine = MovingKeys();
            StartCoroutine(_keysCoroutine);
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _keysTransform = GetComponent<RectTransform>();

            SceneEvents.OnSongChosen += SongChosenHandler;
        }

        public override void Exit()
        {
            base.Exit();
            SceneEvents.OnWrongNotePlayed -= WrongNotePlayedHandler;
            SceneEvents.OnRightNotePlayed -= RightNotePlayedHandler;
            _music.Stop();
            if (_keysCoroutine != null)
            {
                StopCoroutine(_keysCoroutine);
            }
            foreach (Transform key in _keysTransform)
            {
                Destroy(key.gameObject);
            }
        }

        private void RightNotePlayedHandler()
        {
            DOTween.Sequence()
                .Append(_square.DOColor(Color.green, _currentSong.NoteLength / 2))
                .Append(_square.DOColor(Color.white, _currentSong.NoteLength / 2));
        }

        private void WrongNotePlayedHandler()
        {
            DOTween.Sequence()
                .Append(_square.DOColor(Color.red, _currentSong.NoteLength / 2))
                .Append(_square.DOColor(Color.white, _currentSong.NoteLength / 2));
        }

        private void SongChosenHandler(SongInfo currentSong)
        {
            _currentSong = currentSong;
            _music.clip = currentSong.MusicForGroup;
            foreach (var key in _currentSong.SongKeys)
            {
                GameObject _newKey = Instantiate(_keyPrefab, _keysTransform);
                _newKey.GetComponentInChildren<TextMeshProUGUI>().text = key.ToString();
            }
        }

        private IEnumerator MovingKeys()
        {
            yield return null;

            for (int i = 0, j; i < _currentSong.SongKeys.Length; i = j)
            {
                float checkSongTime;
                do
                {
                    yield return null;

                    float currentSongTime = _music.timeSamples / (float)_music.clip.frequency;
                    checkSongTime = currentSongTime / _currentSong.NoteLength;
                    j = (int)checkSongTime;

                    Vector3 newPosition = _keysTransform.localPosition;
                    newPosition.x = -currentSongTime * _keysSpeed;
                    _keysTransform.localPosition = newPosition;
                } while ((checkSongTime > 0f) && (j <= i));

                if (j <= 0) break;
                else if (j < _currentSong.SongKeys.Length)
                {
                    SceneEvents.OnCurrentNoteChanged?.Invoke(_currentSong.SongKeys[i],
                        _currentSong.SongKeys[j]);
                }
            }

            SceneEvents.OnConcertEnded?.Invoke();
        }
    }
}