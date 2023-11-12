namespace RockVoyage
{
    public class PlayerCharacteristics
    {
        private float _energy = Constants.ENERGY_MAX;
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