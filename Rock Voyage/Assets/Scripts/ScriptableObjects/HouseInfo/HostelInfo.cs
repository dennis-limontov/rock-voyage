using Newtonsoft.Json;
using System;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/HouseInfo/HostelInfo")]
    public class HostelInfo : HouseInfo, ILoadSave
    {
        public const int MAP_COST = 60;
        public const int NEWSPAPER_COST = 60;

        [SerializeField]
        private int _costPerNight;
        public int CostPerNight => _costPerNight;

        public bool IsBooked => _reservationDepartureTime > GameCharacteristics.ClockDate;

        private DateTime _reservationDepartureTime = DateTime.UnixEpoch;
        public DateTime ReservationDepartureTime => _reservationDepartureTime;

        public string Name => name;

        private void Awake()
        {
            LoadSaveManager.Add(Name, this);
        }

        private void OnDestroy()
        {
            LoadSaveManager.Remove(Name);
        }

        public void Load(string loadData)
        {
            _reservationDepartureTime = JsonConvert.DeserializeObject<DateTime>(loadData);
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(_reservationDepartureTime);
        }

        public void AddDays(TimeSpan departureDaysToAdd)
        {
            if (!IsBooked)
            {
                _reservationDepartureTime = GameCharacteristics.ClockDate;
            }
            _reservationDepartureTime += departureDaysToAdd;
            if (_reservationDepartureTime.Hour < 10)
            {
                _reservationDepartureTime = _reservationDepartureTime.Subtract(new TimeSpan(1, 0, 0, 0));
            }
            _reservationDepartureTime = new DateTime(_reservationDepartureTime.Year,
                _reservationDepartureTime.Month, _reservationDepartureTime.Day,
                10, 0, 0);
        }
    }
}