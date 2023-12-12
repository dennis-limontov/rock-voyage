using UnityEngine;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Reception : UIBase
    {
        [SerializeField]
        private Button _mapButton;

        [SerializeField]
        private Button _newspaperButton;

        public override void Enter()
        {
            base.Enter();
            UpdateComponentsView();
        }

        public void OnBuyAMapClicked()
        {
            houseInfo.MapInfo.IsMapPurchased = true;
            RVGC.Money -= Constants.MAP_COST;
            UpdateComponentsView();
        }

        public void OnBuyANewspaperClicked()
        {
            houseInfo.MapInfo.IsNewspaperPurchased = true;
            RVGC.Money -= Constants.NEWSPAPER_COST;
            UpdateComponentsView();
        }

        private void UpdateComponentsView()
        {
            HostelInfo hostelInfo = (HostelInfo)houseInfo;
            _mapButton.interactable = ((RVGC.Money >= Constants.MAP_COST)
                && hostelInfo.IsBooked && !hostelInfo.MapInfo.IsMapPurchased);
            _newspaperButton.interactable = ((RVGC.Money >= Constants.NEWSPAPER_COST)
                && hostelInfo.IsBooked && !hostelInfo.MapInfo.IsNewspaperPurchased);
        }
    }
}