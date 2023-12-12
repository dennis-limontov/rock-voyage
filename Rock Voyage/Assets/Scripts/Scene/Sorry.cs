using System;

namespace RockVoyage
{
    public class Sorry : UIActiveOneChild
    {
        public override void Enter()
        {
            base.Enter();
            if (GameCharacteristics.ClockDate <= GameCharacteristics.PlayOnSceneAvailableDate)
            {
                GoToNext();
                EventHub.OnValueChanged?.Invoke(GameAttributes.PlayOnSceneAvailableDate,
                    default, GameCharacteristics.PlayOnSceneAvailableDate);
            }
        }
    }
}