using UnityEngine;

namespace RockVoyage
{
    public class QuestResult : UIActiveOneChild
    {
        [SerializeField]
        private UIBase _winText;

        [SerializeField]
        private UIBase _loseText;

        private bool _questResult;

        public override void Dispose()
        {
            BarEvents.OnQuestEndedWithResult -= QuestEndedWithResultHandler;
            base.Dispose();
        }

        public override void Enter()
        {
            base.Enter();
            ShowResult();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            BarEvents.OnQuestEndedWithResult += QuestEndedWithResultHandler;
        }

        private void QuestEndedWithResultHandler(bool result)
        {
            _questResult = result;
            ShowResult();
        }

        private void ShowResult()
        {
            GoTo(_questResult ? _winText : _loseText);
        }
    }
}