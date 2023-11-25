using UnityEngine;

namespace RockVoyage
{
    public class Asleep : UIActiveOneChild
    {
        private void Awake()
        {
            Init(null, null);
            MapEvents.OnLowEnergy += Enter;
            Exit();
        }

        public override void Enter()
        {
            base.Enter();
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
            Time.timeScale = 0f;
            GameCharacteristics.CurrentPlayer.Sleep();
        }

        public override void Exit()
        {
            base.Exit();
            Time.timeScale = 1f;
        }

        private void OnDestroy()
        {
            MapEvents.OnLowEnergy -= Enter;
        }
    }
}