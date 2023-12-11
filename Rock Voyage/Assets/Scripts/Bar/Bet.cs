using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class Bet : UIActiveAllChildren
    {
        [SerializeField]
        private Button _betButton;

        public override void Enter()
        {
            base.Enter();
            EventHub.OnValueChanged?.Invoke(GameAttributes.BarBetVisitors, 0,
                ((BarController)GetController()).BetVisitors);
        }

        public void OnSliderValueChanged(float newValue)
        {
            _betButton.interactable = (GameCharacteristics.Money >= (int)newValue);
        }
    }
}