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

        private string startText = "You're the brightest star of the night sky, the hottest musical chord of our time, but only you and your mother know about it so far.\n\n" +
            "But that's for now!\n\n" +
            "You've decided to build a career as a rock musician, and your band is already ready to declare itself.\n\n" +
            "Show the world what your talent and diligence are worth!\n\n" +
            "The hearts of millions of fans around the world are already waiting for you and only you on the other side of the music scene!\n\n\n\n";

        private void Start()
        {
            Time.timeScale = 0.25f;
            _textTyper.PrintCompleted.AddListener(PrintCompletedHandler);
            _textTyper.CharacterPrinted.AddListener(CharacterPrintedHandler);
            _textTyper.TypeText(startText);
        }

        private void CharacterPrintedHandler(string printedCharacter)
        {
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