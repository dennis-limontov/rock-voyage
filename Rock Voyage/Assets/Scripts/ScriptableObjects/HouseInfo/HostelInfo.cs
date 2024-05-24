using JsonHelpers;
using System;
using System.Runtime.Serialization;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    [Serializable, DataContract]
    public class HostelInfo : HouseInfo
    {
        public const int MAP_COST = 60;
        public const int NEWSPAPER_COST = 60;

        [field: SerializeField]
        public int CostPerNight { get; private set; }

        public bool IsBooked => ReservationExpirationTime > RVGC.ClockDate;

        [DataMember]
        [SerializeIfGreaterThanCurrent]
        public DateTime ReservationExpirationTime { get; private set; } = DateTime.UnixEpoch;

        public void AddDays(TimeSpan departureDaysToAdd)
        {
            if (!IsBooked)
            {
                ReservationExpirationTime = RVGC.ClockDate;
            }
            if (ReservationExpirationTime.Hour < Constants.NEW_DAY_HOUR)
            {
                departureDaysToAdd -= new TimeSpan(1, 0, 0, 0);
            }
            ReservationExpirationTime += departureDaysToAdd;
            ReservationExpirationTime = new DateTime(ReservationExpirationTime.Year,
                ReservationExpirationTime.Month, ReservationExpirationTime.Day,
                Constants.NEW_DAY_HOUR, 0, 0);
        }
    }
}