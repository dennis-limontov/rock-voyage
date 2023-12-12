using System;
using System.Collections;
using UnityEngine;

namespace RockVoyage
{
    public class StreetMusicController : UIActiveOneChild
    {
        [SerializeField]
        private UIBase _streetMusicAction;

        public override void Dispose()
        {
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
            base.Dispose();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            SceneEvents.OnCountdownEnded += CountdownEndedHandler;
        }

        private void CountdownEndedHandler()
        {
            StartCoroutine(PlayLittleSongPart());
        }

        private IEnumerator PlayLittleSongPart()
        {
            yield return new WaitForSeconds(Constants.STREET_MUSIC_TIME);

            SceneEvents.OnConcertEnded?.Invoke();
        }

        public void OnPlayClicked()
        {
            GoTo(_streetMusicAction);
            ((StreetMusicInfo)houseInfo).PlayAgainTime
                = GameCharacteristics.ClockDate.AddDays(1);
        }
    }
}