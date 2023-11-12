using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class SliderView : GameCharacteristicView
    {
        [SerializeField]
        private Image _sliderImage;

        private Slider _slider;

        private TextMeshProUGUI _sliderText;

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            _slider = GetComponent<Slider>();
            _sliderText = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void UpdateCharacteristic(float oldValue, float newValue)
        {
            base.UpdateCharacteristic(oldValue, newValue);
            _slider.value = newValue;
            _sliderImage.color = _slider.value switch
            {
                < Constants.ENERGY_LIMIT_DANGER => Constants.ENERGY_COLOR_DANGER,
                < Constants.ENERGY_LIMIT_LOW => Constants.ENERGY_COLOR_LOW,
                < Constants.ENERGY_LIMIT_MIDDLE => Constants.ENERGY_COLOR_MIDDLE,
                _ => Constants.ENERGY_COLOR_MAX
            };
        }

        protected override void UpdateCharacteristic(string oldValue, string newValue)
        {
            base.UpdateCharacteristic(oldValue, newValue);
            _sliderText.text = newValue;
        }
    }
}