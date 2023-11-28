using Newtonsoft.Json;
using System;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class PlayerCharacteristics
    {
        private float _energy = Constants.ENERGY_MAX;
        [JsonProperty]
        public float Energy
        {
            get => _energy;
            set
            {
                EventHub.OnValueChanged?.Invoke(GameAttributes.Energy, _energy, value);
                _energy = value;
            }
        }

        public void Sleep()
        {
            DateTime ourDay = RVGC.ClockDate;
            if (ourDay.Hour >= Constants.HOSTEL_NEW_DAY_HOUR)
            {
                ourDay = ourDay.AddDays(1);
            }
            RVGC.ClockDate = new DateTime(ourDay.Year, ourDay.Month, ourDay.Day,
                Constants.HOSTEL_NEW_DAY_HOUR, 0, 0);
            Energy = Constants.ENERGY_MAX;
        }
    }
}