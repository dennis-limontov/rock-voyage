using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Go : UIBase
    {
        private ProStudioInfo _proStudioInfo;

        private Button _goButton;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _proStudioInfo = (ProStudioInfo)houseInfo;
            _goButton = GetComponent<Button>();
            _goButton.interactable = (RVGC.Money >= _proStudioInfo.RecordingCost);
        }

        public void OnGoClicked()
        {
            _proStudioInfo.MakeRecord();
        }
    }
}