using UnityEngine;

namespace RockVoyage
{
    public class BarController : UIActiveOneChild
    {
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

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);

            Visitors = Random.Range(0, ((BarInfo)houseInfo).Capacity);
            BetVisitors = Random.Range(0, Visitors);
        }

        public void DefineQuest(BarQuest barQuest)
        {
            _barQuest = barQuest;
        }
    }

    public enum BarQuest
    {
        Beer = 0,
        Cocktail = 1
    }
}