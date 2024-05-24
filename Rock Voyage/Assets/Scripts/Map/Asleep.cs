using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

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
            if (RVGC.MapInfo.BookedHostel == null)
            {
                if (RVGC.Money >= 0)
                {
                    RVGC.Money /= 2;
                }
            }
            else
            {
                RVGC.Money -= Constants.TAXI_COST;
                GoToNext();
            }
            PlayersList.CurrentPlayer.Sleep();
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