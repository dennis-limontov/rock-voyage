using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ProStudio : UIActiveOneChild
    {
        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            if (RVGC.ClockDate <= RVGC.RecordAvailableDate)
            {
                GoToNext();
            }
        }
    }
}