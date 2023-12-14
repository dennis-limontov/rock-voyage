using UnityEngine;
using UnityEngine.InputSystem;

namespace RockVoyage
{
    using static Constants.PlayerAnimationStates;

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
            SceneEvents.OnCurrentNoteChanged += CurrentNoteChangedHandler;
            SceneEvents.OnSongChosen += SongChosenHandler;
        }

        private void ConcertEndedHandler()
        {
            _animator.Play(IDLE);
            _music.Stop();
        }

        private void CountdownEndedHandler()
        {
            _animator.Play(SING);
            _music.Play();
            _currentNote = ' ';
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

        private void SongChosenHandler(SongInfo currentSong)
        {
            _currentSong = currentSong;
            _music.clip = _currentSong.MusicForSinger;
        }

        private void OnDestroy()
        {
            SceneEvents.OnSongChosen -= SongChosenHandler;
            SceneEvents.OnCurrentNoteChanged -= CurrentNoteChangedHandler;
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