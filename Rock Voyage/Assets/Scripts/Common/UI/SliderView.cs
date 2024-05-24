using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class SliderView : GameCharacteristicView
    {
        public static readonly Gradient SLIDER_COLOR_GRADIENT = new Gradient()
        {
            colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(Color.red, 0.1f),
                new GradientColorKey(new Color(1f, 0.5f, 0f, 1f), 0.4f),
                new GradientColorKey(Color.yellow, 0.7f),
                new GradientColorKey(new Color(0.04f, 0.62f, 0.1f, 1f), 1f),
            },
            mode = GradientMode.Fixed
        };

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

        protected override void UpdateCharacteristic(IFormattable oldValue, IFormattable newValue)
        {
            base.UpdateCharacteristic(oldValue, newValue);
            _slider.value = (float)newValue;
            _sliderImage.color = SLIDER_COLOR_GRADIENT.Evaluate(_slider.value);
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