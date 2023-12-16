using UnityEngine;

namespace RockVoyage
{
    public class Beer : BarQuestController
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
        public int Goal
        {
            get => _goal;
            set
            {
                _goal = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.BeerGoal, 0, value);
            }
        }

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

        public override void Dispose()
        {
            BarEvents.OnBeerQuestStepMade -= BeerQuestStepMadeHandler;
            BarEvents.OnBeerQuestEnded -= BeerQuestEndedHandler;
            base.Dispose();
        }

        public override void Enter()
        {
            base.Enter();
            BeerInfo beerInfo = (BeerInfo)questInfo;
            BeerCurrentVolume = 0;
            int randIndex = Random.Range(0, beerInfo.GoalsAndSteps.Length);
            Goal = beerInfo.GoalsAndSteps[randIndex].Key;
            Step = beerInfo.GoalsAndSteps[randIndex].Value;
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            BarEvents.OnBeerQuestEnded += BeerQuestEndedHandler;
            BarEvents.OnBeerQuestStepMade += BeerQuestStepMadeHandler;
        }

        private void BeerQuestEndedHandler()
        {
            BarEvents.OnQuestEndedWithResult?.Invoke((BeerCurrentVolume == Goal) && (Step >= 0));
        }

        private void BeerQuestStepMadeHandler(int currentPressure)
        {
            if (Step > 0)
            {
                Step--;
                BeerCurrentVolume += currentPressure;
            }
            else
            {
                BarEvents.OnQuestEndedWithResult?.Invoke(false);
            }
        }
    }
}