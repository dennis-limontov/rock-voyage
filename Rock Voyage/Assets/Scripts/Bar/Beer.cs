namespace RockVoyage
{
    public class Beer : UIActiveAllChildren
    {
        private int _beerCurrentVolume;
        public int BeerCurrentVolume
        {
            get => _beerCurrentVolume;
            set
            {
                _beerCurrentVolume = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.BeerCurrentVolume, 0, value);
            }
        }

        private int _goal;
        public int Goal => _goal;

        private int _step;
        public int Step
        {
            get => _step;
            set
            {
                _step = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.BeerSteps, 0, value);
            }
        }
    }
}