using System.Collections;
using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class Keys : MonoBehaviour
    {
        [SerializeField]
        private GameObject _keyPrefab;

        [SerializeField]
        private AudioSource _music;

        private SongInfo _currentSong;

        private float _keysSpeed = 0f;

        private RectTransform _keysTransform;

        private void OnDestroy()
        {
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
            SceneEvents.OnSongChosen -= SongChosenHandler;
        }

        private void Start()
        {
            _keysTransform = GetComponent<RectTransform>();
            GameObject keysCanvas = GetComponentInParent<Canvas>().gameObject;
            keysCanvas.SetActive(false);

            SceneEvents.OnSongChosen += SongChosenHandler;
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
        }

        private void SongChosenHandler(SongInfo currentSong)
        {
            _currentSong = currentSong;
            foreach (var key in _currentSong.ResultKeys)
            {
                GameObject _newKey = Instantiate(_keyPrefab, _keysTransform);
                _newKey.GetComponentInChildren<TextMeshProUGUI>().text = key.ToString();
            }
        }

        private void CountdownEndedHandler()
        {
            // _keysSpeed = _keysTransform.sizeDelta.x / _bsParanoidSO.MusicForGroup.length; // 90400/164 = 22600/41
            _keysSpeed = _keyPrefab.GetComponent<RectTransform>().sizeDelta.x
                * _currentSong.ResultKeys.Length / _currentSong.MusicForGroup.length;
            StartCoroutine(MovingKeys());
        }

        private IEnumerator MovingKeys()
        {
            for (int i = 0, j = 0; i < _currentSong.ResultKeys.Length; i = j)
            {
                while (j <= i)
                {
                    float currentSongTime = _music.timeSamples / (float)_music.clip.frequency;
                    j = (int)(currentSongTime / _currentSong.NoteLength);

                    Vector3 newPosition = _keysTransform.localPosition;
                    newPosition.x = -currentSongTime * _keysSpeed;
                    _keysTransform.localPosition = newPosition;
                    // _keysTransform.position -= new Vector3(_keysSpeed * Time.deltaTime, 0f);

                    yield return null;
                }
                if (j < _currentSong.ResultKeys.Length)
                {
                    SceneEvents.OnCurrentNoteChanged?.Invoke(_currentSong.ResultKeys[i],
                    _currentSong.ResultKeys[j]);
                }
            }

            foreach (Transform key in _keysTransform)
            {
                Destroy(key.gameObject);
            }

            SceneEvents.OnConcertEnded?.Invoke();
        }
    }
}