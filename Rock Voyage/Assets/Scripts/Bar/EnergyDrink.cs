using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class EnergyDrink : UIBase
    {
        private Button _energyDrinkButton;

        public override void Enter()
        {
            base.Enter();
            _energyDrinkButton.interactable = !GameCharacteristics.IsEnergyDrinkUsed;
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _energyDrinkButton = GetComponent<Button>();
        }

        public void OnEnergyDrinkClicked()
        {
            PlayersList.CurrentPlayer.Energy = Mathf.Clamp(PlayersList.CurrentPlayer.Energy
                + BarInfo.ENERGY_DRINK_EFFECT, 0f, Constants.ENERGY_MAX);
            GameCharacteristics.IsEnergyDrinkUsed = true;
            _energyDrinkButton.interactable = false;
        }
    }
}