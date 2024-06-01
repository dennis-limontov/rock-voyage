using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    using static Constants.Scenes;

    public class PauseMenu : UIBase
    {
        [SerializeField]
        private CanvasGroup _buttonsCanvasGroup;

        [SerializeField]
        private GameObject _yesNoPanel;

        public override void Enter()
        {
            base.Enter();
            Time.timeScale = 0f;
        }

        public override void Exit()
        {
            base.Exit();
            Time.timeScale = 1f;
        }

        public void OnPause()
        {
            if (IsActive)
            {
                Exit();
            }
            else
            {
                Enter();
            }
        }

        public void OnSaveGameClicked()
        {
            LoadSaveManager.Save();
        }

        public void OnLoadGameClicked()
        {
            LoadSaveManager.Load();
            Exit();
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
            Exit();
            LoadSaveManager.NeedSave = false;
            SceneManager.LoadScene(MAIN_MENU);
        }
    }
}