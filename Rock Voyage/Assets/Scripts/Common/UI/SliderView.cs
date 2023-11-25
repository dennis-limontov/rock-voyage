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

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _slider = GetComponent<Slider>();
            _sliderText = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void UpdateCharacteristic(float oldValue, float newValue)
        {
            base.UpdateCharacteristic(oldValue, newValue);
            _slider.value = newValue;
            _sliderImage.color = _slider.value switch
            {
                < Constants.SLIDER_LIMIT_DANGER => Constants.SLIDER_COLOR_DANGER,
                < Constants.SLIDER_LIMIT_LOW => Constants.SLIDER_COLOR_LOW,
                < Constants.SLIDER_LIMIT_MIDDLE => Constants.SLIDER_COLOR_MIDDLE,
                _ => Constants.SLIDER_COLOR_MAX
            };
        }

        protected override void UpdateCharacteristic(string oldValue, string newValue)
        {
            base.UpdateCharacteristic(oldValue, newValue);
            if (_sliderText != null)
            {
                _sliderText.text = newValue;
            }
        }
    }
}