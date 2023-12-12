using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Go : UIBase
    {
        private Button _goButton;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _goButton = GetComponent<Button>();
            _goButton.interactable = (RVGC.Money >= Constants.PRO_STUDIO_RECORD_COST);
        }

        public void OnGoClicked()
        {
            RVGC.Money -= Constants.PRO_STUDIO_RECORD_COST;
            RVGC.Fame += Constants.FAME_INCREMENT;
            RVGC.RecordAvailableDate = RVGC.ClockDate.AddDays(7);
            RVGC.ClockDate += Constants.PRO_STUDIO_TIME;
        }
    }
}