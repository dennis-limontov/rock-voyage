using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private SongInfo _firstSong;

        public void OnNewGameClicked()
        {
            ResetGameData();
            SceneManager.LoadScene(Constants.CUT_SCENE_START);
        }

        public void OnLoadGameClicked()
        {
            SceneManager.LoadScene(Constants.START_CITY_NAME);
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