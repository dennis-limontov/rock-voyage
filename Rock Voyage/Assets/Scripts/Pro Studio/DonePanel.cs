using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class DonePanel : UIActiveAllChildren
    {
        public override void Enter()
        {
            base.Enter();

            RVGC.Money -= Constants.PRO_STUDIO_RECORD_COST;
            RVGC.Fame += Constants.FAME_INCREMENT;
            RVGC.RecordAvailableDate = RVGC.ClockDate.AddDays(7);
            RVGC.ClockDate += Constants.PRO_STUDIO_TIME;
        }
    }
}