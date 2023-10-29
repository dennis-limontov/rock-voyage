using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class HostelDialogue : MonoBehaviour
    {
        [SerializeField]
        private GameObject _variants1;

        [SerializeField]
        private GameObject _variants2;

        [SerializeField]
        private TextMeshProUGUI _costText;

        [SerializeField]
        private TextMeshProUGUI _reservationDateText;

        [SerializeField]
        private Button _mapButton;

        [SerializeField]
        private Button _newspaperButton;

        [SerializeField]
        private Button _sleepButton;

        [SerializeField]
        private HostelInfo _hostelInfo;

        private TimeSpan _reservationDays;

        private void Start()
        {
            if (_hostelInfo.IsBooked && !_hostelInfo.MapInfo.IsMapPurchased)
            {
                _mapButton.interactable = true;
            }
            if (_hostelInfo.IsBooked && !_hostelInfo.MapInfo.IsNewspaperPurchased)
            {
                _newspaperButton.interactable = true;
            }
            if (!_hostelInfo.IsBooked)
            {
                _sleepButton.interactable = false;
            }
        }

        // Variant 1-1
        public void OnSpendTheNightClicked()
        {
            _variants1.SetActive(false);
            _variants2.SetActive(true);
        }

        // Variant 1-2
        public void OnBuyAMapClicked()
        {
            // to buy a map
            _hostelInfo.MapInfo.IsMapPurchased = true;
            _mapButton.interactable = false;
        }

        // Variant 1-3
        public void OnBuyANewspaperClicked()
        {
            // to buy a newspaper
            _hostelInfo.MapInfo.IsNewspaperPurchased = true;
            _newspaperButton.interactable = false;
        }

        // Variant 2-1
        public void OnGoToSleepClicked()
        {
            DateTime ourDay = RVGC.ClockDate;
            if (ourDay.Hour >= 10)
            {
                ourDay = ourDay.AddDays(1);
            }
            RVGC.ClockDate = new DateTime(ourDay.Year, ourDay.Month, ourDay.Day,
                Constants.HOSTEL_NEW_DAY_HOUR, 0, 0);
            OnBackClicked();
        }

        // Variant 2-2-2
        public void OnDaysChanged(string newDays)
        {
            int newDaysToInt = (newDays != string.Empty) ? int.Parse(newDays) : 0;
            _reservationDays = new TimeSpan(newDaysToInt, 0, 0, 0);
            int cost = newDaysToInt * _hostelInfo.CostPerNight;
            _costText.text = cost.ToString();
        }

        // Variant 2-3
        public void OnReservationDateChanged()
        {
            if (!_hostelInfo.MapInfo.IsMapPurchased)
            {
                _mapButton.interactable = true;
            }
            if (!_hostelInfo.MapInfo.IsNewspaperPurchased)
            {
                _newspaperButton.interactable = true;
            }
            _sleepButton.interactable = true;
            _hostelInfo.AddDays(_reservationDays);
            _reservationDateText.text = _hostelInfo.ReservationDepartureTime.ToString();
        }

        // Variant 2-4
        public void OnBackClicked()
        {
            _variants2.SetActive(false);
            _variants1.SetActive(true);
        }
    }
}