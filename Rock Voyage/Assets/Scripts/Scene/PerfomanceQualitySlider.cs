using System;
using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class PerfomanceQualitySlider : MonoBehaviour
    {
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            Events.OnWrongNotePlayed += WrongNotePlayedHandler;
        }

        private void WrongNotePlayedHandler(float penalty)
        {
            _slider.value -= penalty;
        }

        private void OnDestroy()
        {
            Events.OnWrongNotePlayed -= WrongNotePlayedHandler;
        }
    }
}