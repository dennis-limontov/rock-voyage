using System;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/HostelInfo")]
    public class HostelInfo : HouseInfo
    {
        [SerializeField]
        private int _costPerNight;
        public int CostPerNight => _costPerNight;

        public bool IsBooked => _reservationDepartureTime > GameCharacteristics.ClockDate;

        private DateTime _reservationDepartureTime = DateTime.UnixEpoch;
        public DateTime ReservationDepartureTime => _reservationDepartureTime;

        public void AddDays(TimeSpan departureDaysToAdd)
        {
            if (!IsBooked)
            {
                _reservationDepartureTime = GameCharacteristics.ClockDate;
            }
            _reservationDepartureTime += departureDaysToAdd;
        }
    }
}