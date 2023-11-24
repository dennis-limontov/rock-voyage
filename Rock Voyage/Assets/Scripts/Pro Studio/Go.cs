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
    }
}