using System;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class EnergySlider : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private Image _sliderImage;

        private PlayerCharacteristics _playerCharacteristics;

        private void Start()
        {
            _playerCharacteristics = GameCharacteristics.players[0];
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        private void ClockDateChangedHandler(DateTime dateTimeOld, DateTime dateTimeNew)
        {
            _slider.value = _playerCharacteristics.Energy;
            _sliderImage.color = _slider.value switch
            {
                < Constants.ENERGY_LIMIT_DANGER => Constants.ENERGY_COLOR_DANGER,
                < Constants.ENERGY_LIMIT_LOW => Constants.ENERGY_COLOR_LOW,
                < Constants.ENERGY_LIMIT_MIDDLE => Constants.ENERGY_COLOR_MIDDLE,
                _ => Constants.ENERGY_COLOR_MAX
            };
        }
    }
}