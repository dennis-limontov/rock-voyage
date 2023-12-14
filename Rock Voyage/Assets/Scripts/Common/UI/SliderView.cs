using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class SliderView : GameCharacteristicView
    {
        public const float SLIDER_LIMIT_MIDDLE = 0.7f;
        public const float SLIDER_LIMIT_LOW = 0.4f;
        public const float SLIDER_LIMIT_DANGER = 0.1f;
        public static readonly Color SLIDER_COLOR_MAX = new Color(0.04f, 0.62f, 0.1f, 1f);
        public static readonly Color SLIDER_COLOR_MIDDLE = Color.yellow;
        public static readonly Color SLIDER_COLOR_LOW = new Color(1f, 0.5f, 0f, 1f);
        public static readonly Color SLIDER_COLOR_DANGER = Color.red;

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
                < SLIDER_LIMIT_DANGER => SLIDER_COLOR_DANGER,
                < SLIDER_LIMIT_LOW => SLIDER_COLOR_LOW,
                < SLIDER_LIMIT_MIDDLE => SLIDER_COLOR_MIDDLE,
                _ => SLIDER_COLOR_MAX
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