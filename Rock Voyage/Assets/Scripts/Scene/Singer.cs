using UnityEngine;
using UnityEngine.InputSystem;

namespace RockVoyage
{
    public class Singer : MonoBehaviour
    {
        private SongInfo _currentSong;

        private AudioSource _music;

        private char _currentNote;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _music = GetComponent<AudioSource>();
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
            SceneEvents.OnSongChosen += SongChosenHandler;
            SceneEvents.OnCurrentNoteChanged += CurrentNoteChangedHandler;
        }

        private void ConcertEndedHandler()
        {
            _animator.Play(Constants.PLAYER_STATE_IDLE);
            _music.Stop();
        }

        private void CurrentNoteChangedHandler(char currentNote, char nextNote)
        {
            if (currentNote != _currentNote)
            {
                SceneEvents.OnWrongNotePlayed?.Invoke();
                _music.mute = true;
            }
            else
            {
                if (currentNote != ' ')
                {
                    SceneEvents.OnRightNotePlayed?.Invoke();
                }
                _music.mute = false;
            }

            _currentNote = ' ';
        }

        private void CountdownEndedHandler()
        {
            _animator.Play(Constants.PLAYER_STATE_SING);
            _music.Play();
            _currentNote = ' ';
        }

        private void SongChosenHandler(SongInfo currentSong)
        {
            _music.clip = currentSong.MusicForSinger;
            _currentSong = currentSong;
        }

        private void OnDestroy()
        {
            SceneEvents.OnCurrentNoteChanged -= CurrentNoteChangedHandler;
            SceneEvents.OnSongChosen -= SongChosenHandler;
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
            SceneEvents.OnConcertEnded -= ConcertEndedHandler;
        }

        public void OnNotePlayed(InputAction.CallbackContext inputContext)
        {
            if (inputContext.phase == InputActionPhase.Performed)
            {
                _currentNote = char.Parse(inputContext.control.name);
            }
        }
    }
}