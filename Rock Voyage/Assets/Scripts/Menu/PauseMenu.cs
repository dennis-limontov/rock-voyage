using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _buttonsCanvasGroup;

        [SerializeField]
        private Canvas _pauseMenuCanvas;

        [SerializeField]
        private GameObject _helpPanel;

        [SerializeField]
        private GameObject _yesNoPanel;

        public void OnPause()
        {
            if (_pauseMenuCanvas.gameObject.activeSelf)
            {
                OnContinueClicked();
            }
            else
            {
                Time.timeScale = 0f;
                _pauseMenuCanvas.gameObject.SetActive(true);
            }
        }

        public void OnContinueClicked()
        {
            Time.timeScale = 1f;
            _pauseMenuCanvas.gameObject.SetActive(false);
        }

        public void OnSaveGameClicked()
        {
            LoadSaveManager.Save();
        }

        public void OnLoadGameClicked()
        {
            LoadSaveManager.Load();
            OnContinueClicked();
        }

        public void OnHelpClicked()
        {
            _helpPanel.SetActive(true);
        }

        public void OnHelpBackClicked()
        {
            _helpPanel.SetActive(false);
        }

        public void OnSettingsClicked()
        {

        }

        public void OnBackToMainMenuClicked()
        {
            _buttonsCanvasGroup.blocksRaycasts = false;
            _yesNoPanel.SetActive(true);
        }

        public void OnNoButtonClicked()
        {
            _yesNoPanel.SetActive(false);
            _buttonsCanvasGroup.blocksRaycasts = true;
        }

        public void OnYesButtonClicked()
        {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE_NAME);
        }
    }
}