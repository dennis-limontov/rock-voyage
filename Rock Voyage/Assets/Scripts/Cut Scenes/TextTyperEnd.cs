using RedBlueGames.Tools.TextTyper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class TextTyperEnd : MonoBehaviour
    {
        [SerializeField]
        private TextTyper _textTyper;

        private string badEndText = "The rock'n'roll car didn't have time to run a red light and was left behind by the rapidly gaining popularity of new pop genres.\n\n" +
            "You never managed to shoot among the numerous competitors, which, unfortunately, means that your time has passed.\n\n";
        private string goodEndText = "Your band is destined to make history!\n\n" +
            "Soon, T-shirts with your logo will become commonplace in the modern rock wardrobe.\n\n" +
            "The pursuit of money and fame is behind you, and now you are one on one with pure art.\n\n";

        private void Start()
        {
            Time.timeScale = 0.25f;
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
