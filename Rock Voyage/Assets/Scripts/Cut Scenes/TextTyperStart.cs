using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    [RequireComponent(typeof(AudioSource))]
    public class TextTyperStart : MonoBehaviour
    {
        [SerializeField]
        private TextTyper _textTyper;

        [SerializeField]
        private BlinkingText _continueText;

        private const float TYPING_PAUSE = 0.05f;

        private AudioSource _audioSource;

        private TextMeshProUGUI _text;

        private string _startText = "You're the brightest star of the night sky, the hottest musical chord of our time, but only you and your mother know about it so far.\n\n" +
            "But that's for now!\n\n" +
            "You've decided to build a career as a rock musician, and your band is already ready to declare itself.\n\n" +
            "Show the world what your talent and diligence are worth!\n\n" +
            "The hearts of millions of fans around the world are already waiting for you and only you on the other side of the music scene!";

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            _text = GetComponent<TextMeshProUGUI>();
            _textTyper.PrintCompleted.AddListener(PrintCompletedHandler);
            _textTyper.CharacterPrinted.AddListener(CharacterPrintedHandler);
            _textTyper.TypeText(_startText, TYPING_PAUSE);
        }

        private void CharacterPrintedHandler(string printedCharacter)
        {
            if ((_text.pageToDisplay < _text.textInfo.pageCount)
                && (_text.textInfo.pageInfo[_text.pageToDisplay + 1].firstCharacterIndex
                < _text.maxVisibleCharacters))
            {
                _text.pageToDisplay++;
            }
        }

        private void PrintCompletedHandler()
        {
            _audioSource.Stop();

            _continueText.StartBlinking();
        }

        public void OnContinueGameClicked(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (_continueText.IsActivated)
                {
                    _continueText.StopBlinking();
                    SceneManager.LoadScene(Constants.START_CITY_NAME);
                }
                else
                {
                    _continueText.StartBlinking();
                }
            }
        }
    }
}