using RedBlueGames.Tools.TextTyper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class TextTyperEnd : MonoBehaviour
    {
        [SerializeField]
        private TextTyper _textTyper;

        private string badEndText = "Game 11111111111111111\n" +
            "Lost 22222222222222222";
        private string goodEndText = "Game 333333333333333\n" +
            "Won 444444444444444";

        private void Start()
        {
            Time.timeScale = 0.5f;
            if ((GameCharacteristics.Fame == 1f) || (GameCharacteristics.Money >= 10000))
            {
                _textTyper.TypeText(goodEndText);
            }
            else if (GameCharacteristics.ClockDate.Year == 1980)
            {
                _textTyper.TypeText(badEndText);
            }
            _textTyper.PrintCompleted.AddListener(PrintCompletedHandler);
        }

        private void PrintCompletedHandler()
        {
            Time.timeScale = 1f;
        }

        public void OnEndGameClicked()
        {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE_NAME);
        }
    }
}
