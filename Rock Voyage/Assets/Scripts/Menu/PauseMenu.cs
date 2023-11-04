using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private Canvas _pauseMenuCanvas;

        [SerializeField]
        private GameObject _coveringPanel;

        public void OnPause()
        {
            Time.timeScale = 0f;
            _pauseMenuCanvas.gameObject.SetActive(true);
        }

        public void OnContinueClicked()
        {
            Time.timeScale = 1f;
            _pauseMenuCanvas.gameObject.SetActive(false);
        }

        public void OnSaveGameClicked()
        {

        }

        public void OnLoadGameClicked()
        {

        }

        public void OnSettingsClicked()
        {

        }

        public void OnBackToMainMenuClicked()
        {
            _coveringPanel.SetActive(true);
        }

        public void OnNoButtonClicked()
        {
            _coveringPanel.SetActive(false);
        }

        public void OnYesButtonClicked()
        {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE_NAME);
        }
    }
}