using UnityEngine;
using UnityEngine.UI;

namespace RockVoyage
{
    public class Pressure : UIActiveAllChildren
    {
        [SerializeField]
        private Button _moreButton;

        [SerializeField]
        private Button _sameButton;

        [SerializeField]
        private Button _lessButton;

        [SerializeField]
        private Button _stopButton;

        private int _pressureIndex = 0;
        private int PressureIndex
        {
            get => _pressureIndex;
            set
            {
                _pressureIndex = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.BeerPressure, 0, CurrentPressure);
            }
        }

        private int[] _pressureValues = { 0, 10, 25, 40, 65, 80 };
        public int CurrentPressure => _pressureValues[_pressureIndex];

        private Beer _beer;

        public override void Enter()
        {
            base.Enter();
            UpdateComponentsView();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _beer = (Beer)parent;
        }

        public void OnMoreButtonClicked()
        {
            PressureIndex++;
            MakeStep();
        }

        public void OnSameButtonClicked()
        {
            MakeStep();
        }

        public void OnLessButtonClicked()
        {
            PressureIndex--;
            MakeStep();
        }

        public void OnStopButtonClicked()
        {
            PressureIndex = 0;
            if (_beer.BeerCurrentVolume == _beer.Goal)
            {
                // you won
            }
            else
            {
                // you lost
            }
        }

        private void MakeStep()
        {
            Beer beer = (Beer)parent;
            if (beer.Step > 0)
            {
                beer.Step--;
                beer.BeerCurrentVolume += CurrentPressure;
            }
            else
            {
                // you lost
            }
            UpdateComponentsView();
        }

        private void UpdateComponentsView()
        {
            _moreButton.interactable = (_pressureIndex < _pressureValues.Length);
            _sameButton.interactable = _lessButton.interactable = (_pressureIndex > 0);
            _stopButton.interactable = (_pressureIndex == 1);
        }
    }
}