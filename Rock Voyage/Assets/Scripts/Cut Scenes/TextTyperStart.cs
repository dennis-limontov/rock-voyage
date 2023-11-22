using RedBlueGames.Tools.TextTyper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class TextTyperStart : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _printSoundEffect;

        [SerializeField]
        private TextTyper _textTyper;

        private string startText = "Line 11111111111111111\n" +
            "Line 22222222222222222\n" +
            "Line 33333333333333333";

        private void Start()
        {
            Time.timeScale = 0.5f;
            _textTyper.CharacterPrinted.AddListener(CharacterPrintedHandler);
            _textTyper.TypeText(startText);
            _textTyper.PrintCompleted.AddListener(PrintCompletedHandler);
        }

        private void CharacterPrintedHandler(string printedCharacter)
        {
            // Do not play a sound for whitespace
            if (printedCharacter == " " || printedCharacter == "\n")
            {
                return;
            }

            var audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = _printSoundEffect;
            audioSource.Play();
        }

        private void PrintCompletedHandler()
        {
            Time.timeScale = 1f;
        }

        public void OnContinueGameClicked()
        {
            SceneManager.LoadScene(Constants.START_CITY_NAME);
        }
    }
}