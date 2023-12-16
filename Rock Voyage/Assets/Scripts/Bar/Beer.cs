using UnityEngine;

namespace RockVoyage
{
    public class Beer : UIActiveOneChild
    {
        [SerializeField]
        private BeerInfo _beerInfo;

        [SerializeField]
        private CloseButton _closeButton;

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
            _closeButton.gameObject.SetActive(false);
            BeerCurrentVolume = 0;
            int randIndex = Random.Range(0, _beerInfo.GoalsAndSteps.Length);
            Goal = _beerInfo.GoalsAndSteps[randIndex].Key;
            Step = _beerInfo.GoalsAndSteps[randIndex].Value;
        }

        public override void Exit()
        {
            base.Exit();
            _closeButton.gameObject.SetActive(true);
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            BarEvents.OnBeerQuestEnded += BeerQuestEndedHandler;
            BarEvents.OnBeerQuestStepMade += BeerQuestStepMadeHandler;
            _beerInfo.FillInfo();
        }

        private void BeerQuestEndedHandler()
        {
            GoToNext();

            BarController barController = (BarController)GetController();
            int moneyProfit = barController.Bet;
            if ((BeerCurrentVolume == Goal) && (Step >= 0))
            {
                BarEvents.OnBeerQuestEndedWithResult?.Invoke(true);
                moneyProfit *= (barController.BetVisitors + 1);
                GameCharacteristics.Money += moneyProfit;
            }
            else
            {
                BarEvents.OnBeerQuestEndedWithResult?.Invoke(false);
                moneyProfit *= -1;
            }
            EventHub.OnValueChanged?.Invoke(GameAttributes.MoneyProfit, 0, moneyProfit);
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
                BarEvents.OnBeerQuestEndedWithResult?.Invoke(false);
            }
        }
    }
}