using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class PerfomanceQualitySlider : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private TextMeshProUGUI _percents;

        private void OnDestroy()
        {
            SceneEvents.OnPerfomanceQualityChanged -= PerfomanceQualityChangedHandler;
        }

        private void Start()
        {
            SceneEvents.OnPerfomanceQualityChanged += PerfomanceQualityChangedHandler;
        }

        private void PerfomanceQualityChangedHandler(float currentQuality)
        {
            _slider.value = currentQuality;
            _percents.text = (_slider.value * 100f).ToString("f2") + " %";
        }
    }
}