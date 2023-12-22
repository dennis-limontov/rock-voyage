using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class LoadGamePanel : MonoBehaviour
    {
        [SerializeField]
        private Transform _savedGamesPanel;

        [SerializeField]
        private GameObject _savedGamePrefab;

        private string[] _savedGames;

        private void OnEnable()
        {
            _savedGames = LoadSaveManager.GetSavedGamesList();
            foreach (string savedGame in _savedGames)
            {
                TextMeshProUGUI text = Instantiate(_savedGamePrefab, _savedGamesPanel)
                    .GetComponentInChildren<TextMeshProUGUI>();
                text.text = savedGame;
            }
        }

        private void OnDisable()
        {
            foreach (Transform savedGame in _savedGamesPanel)
            {
                Destroy(savedGame.gameObject);
            }
        }
    }
}
