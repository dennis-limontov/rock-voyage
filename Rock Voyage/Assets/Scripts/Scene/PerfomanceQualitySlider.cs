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
            SceneEvents.OnWrongNotePlayed -= WrongNotePlayedHandler;
        }

        private void Start()
        {
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
        }

        private void WrongNotePlayedHandler(float penalty)
        {
            _slider.value -= penalty;
            _percents.text = (_slider.value * 100f).ToString("f2") + " %";
        }
    }
}