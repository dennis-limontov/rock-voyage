using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RockVoyage
{
    public class Singer : MonoBehaviour
    {
        [SerializeField]
        private Keys _keys;

        private AudioSource _music;

        private char _currentNote;

        private void Start()
        {
            _music = GetComponent<AudioSource>();
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
        }

        private void CountdownEndedHandler()
        {
            _music.Play();
            StartCoroutine(KeysCoroutine());
        }

        private void OnDestroy()
        {
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
        }

        private IEnumerator KeysCoroutine()
        {
            for (int i = 0; i < _keys.ResultKeys.Length; i++)
            {
                _currentNote = ' ';
                yield return new WaitForSeconds(Keys.noteLength);

                if (_keys.ResultKeys[i] != _currentNote)
                {
                    SceneEvents.OnWrongNotePlayed?.Invoke(_keys.Penalty);
                    _music.mute = true;
                }
                else
                {
                    _music.mute = false;
                }
            }

            SceneEvents.OnConcertEnded?.Invoke();
        }

        public void OnNotePlayed(InputAction.CallbackContext inputContext)
        {
            _currentNote = char.Parse(inputContext.control.name);
        }
    }
}