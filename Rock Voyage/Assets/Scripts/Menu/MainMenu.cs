using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    using static Constants.Scenes;

    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private SongInfo _firstSong;

        public void Start ()
        {
            Time.timeScale = 1f;
            ResetGameData();
        }

        public void OnNewGameClicked()
        {
            SceneManager.LoadScene(CUT_SCENE_START);
        }

        public void OnLoadGameClicked()
        {
            LoadSaveManager.Load();
        }

        public void OnAboutClicked()
        {
            SceneManager.LoadScene(ABOUT);
        }

        public void OnExitGameClicked()
        {
            Application.Quit();
        }

        private void ResetGameData()
        {
            GameCharacteristics.Reset();
            GameCharacteristics.AvailableSongs.Add(_firstSong.SongName);
            PlayersList.Reset();
        }
    }
}