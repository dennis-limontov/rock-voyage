using System;
using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class ClockDate : MonoBehaviour
    {
        private TextMeshProUGUI _clockDateInfo;

        private void Start()
        {
            _clockDateInfo = GetComponent<TextMeshProUGUI>();
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        private void ClockDateChangedHandler(DateTime clockDate)
        {
            _clockDateInfo.text = clockDate.ToString();
        }

        private void OnDestroy()
        {
            MapEvents.OnClockDateChanged -= ClockDateChangedHandler;
        }
    }
}