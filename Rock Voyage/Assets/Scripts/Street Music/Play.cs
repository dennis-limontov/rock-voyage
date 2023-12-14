using System;
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
            StreetMusicInfo streetMusicInfo = (StreetMusicInfo)houseInfo;
            GoTo(streetMusicInfo.IsAvailable ? _playButton : _nextAvailableTimeText);
            EventHub.OnValueChanged?.Invoke(GameAttributes.StreetMusicAvailableDate,
                DateTime.UnixEpoch, streetMusicInfo.PlayAgainTime);
        }
    }
}