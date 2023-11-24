using UnityEngine;

namespace RockVoyage
{
    public class Play : UIActiveOneChild
    {
        [SerializeField]
        private UIBase _playButton;

        [SerializeField]
        private UIBase _nextAvailableTimeText;

        public override void Enter()
        {
            base.Enter();
            GoTo(((StreetMusicInfo)houseInfo).IsAvailable
                ? _playButton : _nextAvailableTimeText);
        }
    }
}