using UnityEngine;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Reception : UIBase
    {
        private HostelInfo _hostelInfo;

        [SerializeField]
        private Button _mapButton;

        [SerializeField]
        private Button _newspaperButton;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _hostelInfo = (HostelInfo)houseInfo;
        }

        public override void Enter()
        {
            base.Enter();
            UpdateComponentsView();
        }

        public void OnBuyAMapClicked()
        {
            _hostelInfo.MapInfo.IsMapPurchased = true;
            RVGC.Money -= HostelInfo.MAP_COST;
            UpdateComponentsView();
        }

        public void OnBuyANewspaperClicked()
        {
            _hostelInfo.MapInfo.IsNewspaperPurchased = true;
            RVGC.Money -= HostelInfo.NEWSPAPER_COST;
            UpdateComponentsView();
        }

        private void UpdateComponentsView()
        {
            _mapButton.interactable = ((RVGC.Money >= HostelInfo.MAP_COST)
                && _hostelInfo.IsBooked && !_hostelInfo.MapInfo.IsMapPurchased);
            _newspaperButton.interactable = ((RVGC.Money >= HostelInfo.NEWSPAPER_COST)
                && _hostelInfo.IsBooked && !_hostelInfo.MapInfo.IsNewspaperPurchased);
        }
    }
}