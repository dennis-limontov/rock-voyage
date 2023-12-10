using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class SliderWithText : MonoBehaviour
    {
        private Slider _slider;

        private TextMeshProUGUI _sliderText;

        private void Start ()
        {
            _slider = GetComponentInChildren<Slider>();
            _sliderText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void OnSliderValueChanged()
        {
            _sliderText.text = _slider.value.ToString();
        }
    }
}