using UnityEngine;

namespace RockVoyage
{
    public class BarController : UIActiveOneChild
    {
        [SerializeField]
        private UIBase _beerQuest;

        [SerializeField]
        private UIBase _cocktailQuest;

        private int _visitors;
        public int Visitors
        {
            get => _visitors;
            private set
            {
                _visitors = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.BarVisitors, 0, _visitors);
            }
        }

        private int _betVisitors;
        public int BetVisitors
        {
            get => _betVisitors;
            private set
            {
                _betVisitors = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.BarBetVisitors, 0, _betVisitors);
            }
        }

        private BarQuest _barQuest;

        private int _bet;
        public int Bet => _bet;

        public override void Dispose()
        {
            base.Dispose();
            BarEvents.OnBeerQuestEndedWithResult -= BeerQuestEndedWithResultHandler;
        }

        public override void Enter()
        {
            base.Enter();

            DefineVisitors();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            BarEvents.OnBeerQuestEndedWithResult += BeerQuestEndedWithResultHandler;
        }

        private void BeerQuestEndedWithResultHandler(bool obj)
        {
            GameCharacteristics.ClockDate = GameCharacteristics.ClockDate.AddHours(Constants.BAR_HOURS_FOR_QUEST);
        }

        public void DefineQuest(int barQuestIndex)
        {
            _barQuest = (BarQuest)barQuestIndex;
        }

        public void DefineVisitors()
        {
            Visitors = Random.Range(0, ((BarInfo)houseInfo).Capacity);
            float localRand = Random.Range(0f, 1f);
            if (localRand < 0.8f)
            {
                BetVisitors = Random.Range(0, Visitors / 5);
            }
            else if (localRand < 0.92f)
            {
                BetVisitors = Random.Range(Visitors / 5, Visitors * 2 / 5);
            }
            else if (localRand < 0.952f)
            {
                BetVisitors = Random.Range(Visitors * 2 / 5, Visitors * 3 / 5);
            }
            else
            {
                BetVisitors = Random.Range(Visitors * 3 / 5, Visitors);
            }
        }

        public void OnBetChosen(float bet)
        {
            _bet = (int)bet;
        }

        public void OnQuestStarted()
        {
            GameCharacteristics.Money -= _bet;
            switch (_barQuest)
            {
                case BarQuest.Beer:
                    GoTo(_beerQuest);
                    break;
                case BarQuest.Cocktail:
                    GoTo(_cocktailQuest);
                    break;
                default:
                    break;
            }
        }
    }

    public enum BarQuest
    {
        Beer = 0,
        Cocktail = 1
    }
}