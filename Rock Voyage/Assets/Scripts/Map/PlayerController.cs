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
            GameCharacteristics.Instance.players.Add(_playerCharacteristics);
        }

        private void Start()
        {
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        private void ClockDateChangedHandler(DateTime dateTimeOld, DateTime dateTimeNew)
        {
            if (_playerCharacteristics.Energy > 0f)
            {
                TimeSpan timeDifference = dateTimeNew - dateTimeOld;
                _playerCharacteristics.Energy -= (float)timeDifference.TotalHours
                    * Constants.ENERGY_CONSUMPTION_PER_HOUR;

                if (_playerCharacteristics.Energy <= 0f)
                {
                    MapEvents.OnLowEnergy?.Invoke();
                }
            }
        }

        private void OnDestroy()
        {
            MapEvents.OnClockDateChanged -= ClockDateChangedHandler;
        }
    }
}