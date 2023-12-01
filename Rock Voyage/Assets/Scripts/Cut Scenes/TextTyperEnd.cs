using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    [RequireComponent(typeof(AudioSource))]
    public class TextTyperEnd : MonoBehaviour
    {
        [SerializeField]
        private TextTyper _textTyper;

        [SerializeField]
        private BlinkingText _continueText;

        private const float TYPING_PAUSE = 0.05f;

        private AudioSource _audioSource;

        private TextMeshProUGUI _text;

        private string _badEndText = "The rock'n'roll car didn't have time to run a red light and was left behind by the rapidly gaining popularity of new pop genres.\n\n" +
            "You never managed to shoot among the numerous competitors, which, unfortunately, means that your time has passed.";
        private string _goodEndText = "Your band is destined to make history!\n\n" +
            "Soon, T-shirts with your logo will become commonplace in the modern rock wardrobe.\n\n" +
            "The pursuit of money and fame is behind you, and now you are one on one with pure art.";

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            _text = GetComponent<TextMeshProUGUI>();
            _textTyper.PrintCompleted.AddListener(PrintCompletedHandler);
            _textTyper.CharacterPrinted.AddListener(CharacterPrintedHandler);
            if ((GameCharacteristics.Fame == 1f) || (GameCharacteristics.Money >= 10000))
            {
                _textTyper.TypeText(_goodEndText, TYPING_PAUSE);
            }
            else if (GameCharacteristics.ClockDate.Year == 1980)
            {
                _textTyper.TypeText(_badEndText, TYPING_PAUSE);
            }
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
                    SceneManager.LoadScene(Constants.MAIN_MENU_SCENE_NAME);
                }
                else
                {
                    _continueText.StartBlinking();
                }
            }
        }
    }
}