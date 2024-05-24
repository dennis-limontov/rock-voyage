using System;
using System.Runtime.Serialization;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    [Serializable, DataContract]
    public class PlayerCharacteristics
    {
        private float _energy = Constants.ENERGY_MAX;
        [DataMember]
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
            if (ourDay.Hour >= Constants.NEW_DAY_HOUR)
            {
                ourDay = ourDay.AddDays(1);
            }
            RVGC.ClockDate = new DateTime(ourDay.Year, ourDay.Month, ourDay.Day,
                Constants.NEW_DAY_HOUR, 0, 0);
            Energy = Constants.ENERGY_MAX;
            RVGC.IsEnergyDrinkUsed = false;
        }

        private void ClockDateChangedHandler(DateTime dateTimeOld, DateTime dateTimeNew)
        {
            if (Energy > 0f)
            {
                TimeSpan timeDifference = dateTimeNew - dateTimeOld;
                Energy -= (float)timeDifference.TotalHours
                    * Constants.ENERGY_CONSUMPTION_PER_HOUR;

                if (Energy <= 0f)
                {
                    MapEvents.OnLowEnergy?.Invoke();
                }
            }
        }

        public void Init()
        {
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        public void Release()
        {
            MapEvents.OnClockDateChanged -= ClockDateChangedHandler;
        }
    }
}