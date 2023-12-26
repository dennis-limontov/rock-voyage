using System;
using UnityEngine;

namespace RockVoyage
{
    public class Attention : MonoBehaviour
    {
        [SerializeField]
        private PauseMenu _pauseMenuPanel;

        [SerializeField]
        private GameObject _helpPanel;

        private const string ATTENTION = "attention";

        private void Start()
        {
            if (PlayerPrefs.HasKey(ATTENTION))
            {
                gameObject.SetActive(Convert.ToBoolean(PlayerPrefs.GetInt(ATTENTION)));
            }
        }

        public void OnAttentionClicked()
        {
            _pauseMenuPanel.Enter();
            _helpPanel.SetActive(true);
            PlayerPrefs.SetInt(ATTENTION, Convert.ToInt32(false));
            gameObject.SetActive(false);
        }
    }
}