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
            SceneManager.LoadScene(Constants.START_CITY_NAME);
        }

        public void OnExitGameClicked()
        {
            Application.Quit();
        }

        private void ResetGameData()
        {
            GameCharacteristics.ClockDate = DateTime.UnixEpoch;
            GameCharacteristics.Fame = 0f;
            GameCharacteristics.Money = Constants.MONEY_AT_START;
            GameCharacteristics.players.Clear();
            GameCharacteristics.AvailableSongs.Clear();
            GameCharacteristics.AvailableSongs.Add(_firstSong);
            GameCharacteristics.RecordAvailableDate = DateTime.UnixEpoch;
        }
    }
}