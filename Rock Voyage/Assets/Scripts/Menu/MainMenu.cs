using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class MainMenu : MonoBehaviour
    {
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
            GameCharacteristics.RecordAvailableDate = DateTime.UnixEpoch;
        }
    }
}