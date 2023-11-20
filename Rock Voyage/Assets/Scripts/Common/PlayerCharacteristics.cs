using Newtonsoft.Json;

namespace RockVoyage
{
    public class PlayerCharacteristics
    {
        [JsonProperty]
        private float _energy = Constants.ENERGY_MAX;
        [JsonIgnore]
        public float Energy
        {
            get => _energy;
            set
            {
                EventHub.OnValueChanged?.Invoke(GameAttributes.Energy, _energy, value);
                _energy = value;
            }
        }
    }
}