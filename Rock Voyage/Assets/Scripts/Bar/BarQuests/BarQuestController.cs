using UnityEngine;

namespace RockVoyage
{
    public abstract class BarQuestController : UIActiveAllChildren
    {
        [SerializeField]
        protected BarQuestInfo questInfo;

        [SerializeField]
        private CloseButton _closeButton;

        public override void Enter()
        {
            base.Enter();
            _closeButton.transform.parent.gameObject.SetActive(false);
        }

        public override void Exit()
        {
            _closeButton.transform.parent.gameObject.SetActive(true);
            base.Exit();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            questInfo.FillInfo();
        }
    }
}
