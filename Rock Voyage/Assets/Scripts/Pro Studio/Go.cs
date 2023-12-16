using System;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Go : UIBase
    {
        public const float FAME_INCREMENT = 0.01f;
        public static readonly TimeSpan RECORD_TIME = new TimeSpan(6, 0, 0);

        private Button _goButton;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _goButton = GetComponent<Button>();
            _goButton.interactable = (RVGC.Money >= ProStudioInfo.RECORD_COST);
        }

        public void OnGoClicked()
        {
            RVGC.Money -= ProStudioInfo.RECORD_COST;
            RVGC.Fame += FAME_INCREMENT;
            RVGC.RecordAvailableDate = RVGC.ClockDate.AddDays(ProStudioInfo.RECORD_AVAILABLE_DATE_PAUSE);
            RVGC.ClockDate += RECORD_TIME;
        }
    }
}