using UnityEngine;

namespace RockVoyage
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerCharacteristics _playerCharacteristics;

        private void Awake()
        {
            PlayersList.Instance.CurrentPlayerName = "Player";
            _playerCharacteristics = PlayersList.CurrentPlayer;
        }

        private void Start()
        {
            _playerCharacteristics.Init();
        }

        private void OnDestroy()
        {
            _playerCharacteristics.Release();
        }
    }
}