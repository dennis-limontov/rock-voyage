using UnityEngine;

namespace RockVoyage
{
    public class Asleep : UIActiveOneChild
    {
        public override void Dispose()
        {
            MapEvents.OnLowEnergy -= Enter;
            base.Dispose();
        }

        public override void Enter()
        {
            base.Enter();
            Time.timeScale = 0f;
            if ((GameCharacteristics.HostelInfo == null) || !GameCharacteristics.HostelInfo.IsBooked)
            {
                if (GameCharacteristics.Money >= 0)
                {
                    GameCharacteristics.Money /= 2;
                }
            }
            else
            {
                GameCharacteristics.Money -= Constants.TAXI_COST;
                GoToNext();
            }
            GameCharacteristics.CurrentPlayer.Sleep();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            MapEvents.OnLowEnergy += Enter;
        }

        public override void Exit()
        {
            Time.timeScale = 1f;
            base.Exit();
        }
    }
}