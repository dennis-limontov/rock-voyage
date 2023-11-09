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
            GoTo(((StreetMusicController)GetController()).StreetMusicInfo.IsAvailable
                ? _playButton : _nextAvailableTimeText);
        }
    }
}