using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Reservation : UIBase
    {
        [SerializeField]
        private Button _sleepButton;

        [SerializeField]
        private TextMeshProUGUI _costValueText;

        [SerializeField]
        private Button _okButton;

        [SerializeField]
        private TextMeshProUGUI _reservationDateText;

        private TimeSpan _reservationDays;

        private int _reservationCost;

        public override void Enter()
        {
            base.Enter();
            UpdateComponentsView();
        }

        public void OnGoToSleepClicked()
        {
            RVGC.CurrentPlayer.Sleep();

            ((UIActiveOneChild)GetController()).GoToPrevious();
        }

        public void OnDaysChanged(string newDays)
        {
            int newDaysToInt = newDays.Equals(string.Empty) ? 0 : int.Parse(newDays);
            _reservationDays = new TimeSpan(newDaysToInt, 0, 0, 0);
            _reservationCost = newDaysToInt * ((HostelInfo)houseInfo).CostPerNight;

            UpdateComponentsView();
        }

        public void OnOkClicked()
        {
            if (RVGC.Money >= _reservationCost)
            {
                RVGC.Money -= _reservationCost;
                ((HostelInfo)houseInfo).AddDays(_reservationDays);
                RVGC.HostelInfo = (HostelInfo)houseInfo;

                UpdateComponentsView();
            }
        }

        private void UpdateComponentsView()
        {
            HostelInfo hostelInfo = (HostelInfo)houseInfo;
            _sleepButton.interactable = hostelInfo.IsBooked;
            _costValueText.text = _reservationCost.ToString();
            _okButton.interactable = (RVGC.Money >= _reservationCost);
            if (hostelInfo.IsBooked)
            {
                _reservationDateText.text = hostelInfo.ReservationDepartureTime
                    .ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
            }
        }
    }
}