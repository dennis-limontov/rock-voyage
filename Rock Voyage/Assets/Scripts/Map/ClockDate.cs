using System;
using System.Globalization;
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

        private void ClockDateChangedHandler(DateTime clockDateOld, DateTime clockDateNew)
        {
            _clockDateInfo.text = clockDateNew.ToString("yyyy/MM/dd hh:mm tt", CultureInfo.InvariantCulture);
        }

        private void OnDestroy()
        {
            MapEvents.OnClockDateChanged -= ClockDateChangedHandler;
        }
    }
}