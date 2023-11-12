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
            _playerCharacteristics = GameCharacteristics.CurrentPlayer;
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        private void ClockDateChangedHandler(DateTime dateTimeOld, DateTime dateTimeNew)
        {
            _slider.value = _playerCharacteristics.Energy;
        }
    }
}