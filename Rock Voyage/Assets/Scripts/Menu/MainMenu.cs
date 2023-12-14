using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    using static Constants.Scenes;

    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private SongInfo _firstSong;

        public void OnNewGameClicked()
        {
            ResetGameData();
            SceneManager.LoadScene(CUT_SCENE_START);
        }

        public void OnLoadGameClicked()
        {
            SceneManager.LoadScene(START_CITY);
            MapEvents.OnSceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler(HouseInfo info)
        {
            MapEvents.OnSceneLoaded -= SceneLoadedHandler;
            LoadSaveManager.Load();
        }

        public void OnExitGameClicked()
        {
            Application.Quit();
        }

        private void ResetGameData()
        {
            GameCharacteristics.Reset();
            GameCharacteristics.AvailableSongs.Add(_firstSong.SongName);
        }
    }
}