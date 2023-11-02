using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class Money : MonoBehaviour
    {
        private TextMeshProUGUI _moneyText;

        private void Start()
        {
            MapEvents.OnMoneyChanged += MoneyChangedHandler;
            _moneyText = GetComponent<TextMeshProUGUI>();
            _moneyText.text = GameCharacteristics.Money.ToString();
        }

        private void MoneyChangedHandler(int previousMoney, int currentMoney)
        {
            _moneyText.text = currentMoney.ToString();
        }
    }
}