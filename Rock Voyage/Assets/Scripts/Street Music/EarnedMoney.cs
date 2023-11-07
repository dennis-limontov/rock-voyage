using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class EarnedMoney : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _coinSound;

        [SerializeField]
        private TextMeshProUGUI _earnedMoneyText;

        private int _earnedMoney = 0;

        private void OnDestroy()
        {
            SceneEvents.OnRightNotePlayed -= RightNotePlayedHandler;
        }

        private void Start()
        {
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnRightNotePlayed += RightNotePlayedHandler;
        }

        private void ConcertEndedHandler()
        {
            GameCharacteristics.Money += _earnedMoney;
            _earnedMoney = 0;
            _earnedMoneyText.text = "";
        }

        private void RightNotePlayedHandler()
        {
            var earnMoneyChance = Random.Range(0f, 1f);
            if (earnMoneyChance <= Constants.EARN_MONEY_CHANCE)
            {
                _earnedMoney++;
                _earnedMoneyText.text = _earnedMoney.ToString();
                _coinSound.PlayOneShot(_coinSound.clip);
            }
        }
    }
}