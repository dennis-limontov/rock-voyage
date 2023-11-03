using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class MainMenu : MonoBehaviour
    {
        public void OnNewGameClicked()
        {
            SceneManager.LoadScene(Constants.START_CITY_NAME);
        }

        public void OnExitGameClicked()
        {
            Application.Quit();
        }
    }
}