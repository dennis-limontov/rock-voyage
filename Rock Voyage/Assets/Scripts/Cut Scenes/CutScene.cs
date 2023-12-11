using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class CutScene : MonoBehaviour
    {
        [SerializeField]
        private TextTyper _textTyper;

        [SerializeField]
        private BlinkingText _continueText;

        [SerializeField]
        [TextArea(5, 10)]
        private string _badEndText = "The rock'n'roll car didn't have time to run a red light and was left behind by the rapidly gaining popularity of new pop genres.\n\n" +
            "You never managed to shoot among the numerous competitors, which, unfortunately, means that your time has passed.";

        [SerializeField]
        [TextArea(5, 10)]
        private string _goodEndText = "Your band is destined to make history!\n\n" +
            "Soon, T-shirts with your logo will become commonplace in the modern rock wardrobe.\n\n" +
            "The pursuit of money and fame is behind you, and now you are one on one with pure art.";

        [SerializeField]
        [TextArea(5, 10)]
        private string _startText = "You're the brightest star of the night sky, the hottest musical chord of our time, but only you and your mother know about it so far.\n\n" +
            "But that's for now!\n\n" +
            "You've decided to build a career as a rock musician, and your band is already ready to declare itself.\n\n" +
            "Show the world what your talent and diligence are worth!\n\n" +
            "The hearts of millions of fans around the world are already waiting for you and only you on the other side of the music scene!";

        [SerializeField]
        private string _sceneName;

        private const float TYPING_PAUSE = 0.05f;

        private AudioSource _audioSource;

        private TextMeshProUGUI _text;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            _text = GetComponent<TextMeshProUGUI>();
            _textTyper.PrintCompleted.AddListener(PrintCompletedHandler);
            _textTyper.CharacterPrinted.AddListener(CharacterPrintedHandler);
            if ((GameCharacteristics.Fame == Constants.GAME_WON_FAME)
                || (GameCharacteristics.Money >= Constants.GAME_WON_MONEY))
            {
                _textTyper.TypeText(_goodEndText, TYPING_PAUSE);
            }
            else if (GameCharacteristics.ClockDate.Year == Constants.GAME_OVER_YEAR)
            {
                _textTyper.TypeText(_badEndText, TYPING_PAUSE);
            }
            else
            {
                _textTyper.TypeText(_startText, TYPING_PAUSE);
            }
            TMP_Text tMP_Text;
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
                    SceneManager.LoadScene(_sceneName);
                }
                else
                {
                    _continueText.StartBlinking();
                }
            }
        }
    }
}