using System;
using UnityEngine;

namespace RockVoyage
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerCharacteristics _playerCharacteristics;

        private void Awake()
        {
            _playerCharacteristics = new PlayerCharacteristics();
            GameCharacteristics.players.Add(_playerCharacteristics);
        }

        private void Start()
        {
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        private void ClockDateChangedHandler(DateTime dateTimeOld, DateTime dateTimeNew)
        {
            TimeSpan timeDifference = dateTimeNew - dateTimeOld;
            _playerCharacteristics.Energy -= (float)timeDifference.TotalHours
                * Constants.ENERGY_CONSUMPTION_PER_HOUR;
        }

        private void OnDestroy()
        {
            MapEvents.OnClockDateChanged -= ClockDateChangedHandler;
        }
    }
}