using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class EarnedMoney : UIBase
    {
        [SerializeField]
        private AudioSource _coinSound;

        [SerializeField]
        private TextMeshProUGUI _earnedMoneyText;

        private int _earnedMoney = 0;

        public override void Dispose()
        {
            SceneEvents.OnRightNotePlayed -= RightNotePlayedHandler;
            SceneEvents.OnConcertEnded -= ConcertEndedHandler;
            base.Dispose();
        }

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
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