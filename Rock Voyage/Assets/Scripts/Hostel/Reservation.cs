using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Reservation : UIBase
    {
        private HostelInfo _hostelInfo;

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

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _hostelInfo = (HostelInfo)houseInfo;
        }

        public override void Enter()
        {
            base.Enter();
            UpdateComponentsView();
        }

        public void OnGoToSleepClicked()
        {
            PlayersList.CurrentPlayer.Sleep();

            ((UIActiveOneChild)GetController()).GoToPrevious();
        }

        public void OnDaysChanged(string newDays)
        {
            int newDaysToInt = newDays.Equals(string.Empty) ? 0 : int.Parse(newDays);
            _reservationDays = new TimeSpan(newDaysToInt, 0, 0, 0);
            _reservationCost = newDaysToInt * _hostelInfo.CostPerNight;

            UpdateComponentsView();
        }

        public void OnOkClicked()
        {
            if (RVGC.Money >= _reservationCost)
            {
                RVGC.Money -= _reservationCost;
                _hostelInfo.AddDays(_reservationDays);

                UpdateComponentsView();
            }
        }

        private void UpdateComponentsView()
        {
            _sleepButton.interactable = _hostelInfo.IsBooked;
            _costValueText.text = _reservationCost.ToString();
            _okButton.interactable = (RVGC.Money >= _reservationCost);
            if (_hostelInfo.IsBooked)
            {
                _reservationDateText.text = _hostelInfo.ReservationExpirationTime.ToString();
            }
        }
    }
}