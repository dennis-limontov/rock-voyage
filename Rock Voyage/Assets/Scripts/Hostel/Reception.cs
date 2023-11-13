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

        private HostelInfo _hostelInfo;

        public override void Enter()
        {
            base.Enter();
            UpdateComponentsView();
        }

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            _hostelInfo = ((HostelController)GetController()).HostelInfo;
        }

        public void OnBuyAMapClicked()
        {
            _hostelInfo.MapInfo.IsMapPurchased = true;
            RVGC.Money -= Constants.MAP_COST;
            UpdateComponentsView();
        }

        public void OnBuyANewspaperClicked()
        {
            _hostelInfo.MapInfo.IsNewspaperPurchased = true;
            RVGC.Money -= Constants.NEWSPAPER_COST;
            UpdateComponentsView();
        }

        private void UpdateComponentsView()
        {
            _mapButton.interactable = ((RVGC.Money >= Constants.MAP_COST)
                && _hostelInfo.IsBooked && !_hostelInfo.MapInfo.IsMapPurchased);
            _newspaperButton.interactable = ((RVGC.Money >= Constants.NEWSPAPER_COST)
                && _hostelInfo.IsBooked && !_hostelInfo.MapInfo.IsNewspaperPurchased);
        }
    }
}