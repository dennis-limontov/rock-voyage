using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

namespace RockVoyage
{
    public class BarController : UIActiveOneChild
    {
        [SerializeField]
        private UIBase _questResultPanel;

        [SerializeField]
        private BarQuestController _beerQuest;

        [SerializeField]
        private BarQuestController _cocktailQuest;

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

        private BarQuest _selectedQuest;

        private int _bet;
        public int Bet => _bet;

        private Dictionary<BarQuest, BarQuestController> _barQuests;

        public override void Dispose()
        {
            base.Dispose();
            BarEvents.OnQuestEndedWithResult -= BeerQuestEndedWithResultHandler;
        }

        public override void Enter()
        {
            base.Enter();

            DefineVisitors();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            BarEvents.OnQuestEndedWithResult += BeerQuestEndedWithResultHandler;
            _barQuests = new Dictionary<BarQuest, BarQuestController>
            {
                { BarQuest.Beer, _beerQuest },
                { BarQuest.Cocktail, _cocktailQuest },
            };
        }

        private void BeerQuestEndedWithResultHandler(bool result)
        {
            GoTo(_questResultPanel);
            GameCharacteristics.ClockDate += BarInfo.QUEST_TIME;
            int moneyProfit = Bet;
            if (result)
            {
                moneyProfit *= (BetVisitors + 1);
                GameCharacteristics.Money += moneyProfit;
            }
            else
            {
                moneyProfit *= -1;
            }
            EventHub.OnValueChanged?.Invoke(GameAttributes.MoneyProfit, 0, moneyProfit);
        }

        public void DefineQuest(int barQuestIndex)
        {
            _selectedQuest = (BarQuest)barQuestIndex;
        }

        public void DefineVisitors()
        {
            Visitors = Range(0, ((BarInfo)houseInfo).Capacity);
            float localRand = Range(0f, 1f);
            if (localRand < 0.8f)
            {
                BetVisitors = Range(0, Visitors / 5);
            }
            else if (localRand < 0.92f)
            {
                BetVisitors = Range(Visitors / 5, Visitors * 2 / 5);
            }
            else if (localRand < 0.952f)
            {
                BetVisitors = Range(Visitors * 2 / 5, Visitors * 3 / 5);
            }
            else
            {
                BetVisitors = Range(Visitors * 3 / 5, Visitors);
            }
        }

        public void OnBetChosen(float bet)
        {
            _bet = (int)bet;
        }

        public void OnQuestStarted()
        {
            GameCharacteristics.Money -= _bet;
            GoTo(_barQuests[_selectedQuest]);
        }
    }

    public enum BarQuest
    {
        Beer = 0,
        Cocktail = 1
    }
}