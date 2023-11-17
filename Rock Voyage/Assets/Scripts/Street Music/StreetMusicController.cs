using System.Collections;
using UnityEngine;

namespace RockVoyage
{
    public class StreetMusicController : UIActiveOneChild
    {
        [SerializeField]
        private UIBase _streetMusicAction;

        [SerializeField]
        private StreetMusicInfo _streetMusicInfo;
        public StreetMusicInfo StreetMusicInfo => _streetMusicInfo;

        public override void Dispose()
        {
            SceneEvents.OnCountdownEnded -= CountdownEndedHandler;
            base.Dispose();
        }

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
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
            _streetMusicInfo.PlayAgainTime = GameCharacteristics.ClockDate.AddDays(1);
        }
    }
}