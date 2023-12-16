using UnityEngine;

namespace RockVoyage
{
    public class SceneController : UIActiveOneChild
    {
        [SerializeField]
        private CloseButton _closeButton;

        [SerializeField]
        private UIBase _countdown;

        private SongInfo _currentSong;

        private float _perfomanceQuality = 1f;
        private float PerfomanceQuality
        {
            get => _perfomanceQuality;
            set
            {
                _perfomanceQuality = value;
                SceneEvents.OnPerfomanceQualityChanged?.Invoke(0, _perfomanceQuality);
            }
        }

        public override void Dispose()
        {
            SceneEvents.OnWrongNotePlayed -= WrongNotePlayedHandler;
            SceneEvents.OnSongChosen -= SongChosenHandler;
            SceneEvents.OnCountdownEnded -= GoToNext;
            SceneEvents.OnConcertEnded -= ConcertEndedHandler;
            base.Dispose();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            SceneEvents.OnConcertEnded += ConcertEndedHandler;
            SceneEvents.OnCountdownEnded += GoToNext;
            SceneEvents.OnSongChosen += SongChosenHandler;
            SceneEvents.OnWrongNotePlayed += WrongNotePlayedHandler;
            this.houseInfo = houseInfo;
        }

        private void ConcertEndedHandler()
        {
            _closeButton.transform.parent.gameObject.SetActive(true);
            if (_currentIndex + 1 < children.Length)
            {
                GoToNext();
                if (houseInfo is SceneInfo sceneInfo)
                {
                    float crowdHappiness = _currentSong.Prominence * _perfomanceQuality;
                    int moneyProfit = (int)(sceneInfo.FansCapacity * crowdHappiness * SceneInfo.PROFIT_PERCENT);
                    GameCharacteristics.Money += moneyProfit;
                    GameCharacteristics.Fame += crowdHappiness / 1000f;
                    EventHub.OnValueChanged?.Invoke(GameAttributes.CrowdHappiness, 0f, crowdHappiness);
                    EventHub.OnValueChanged?.Invoke(GameAttributes.MoneyProfit, 0, moneyProfit);
                    EventHub.OnValueChanged?.Invoke(GameAttributes.PerfomanceQuality, 0f, _perfomanceQuality);
                    GameCharacteristics.PlayOnSceneAvailableDate = GameCharacteristics.ClockDate.AddDays(1);
                }
            }
            else
            {
                ((UIActiveOneChild)GetController()).GoToFirst();
            }
        }

        private void SongChosenHandler(SongInfo currentSong)
        {
            _currentSong = currentSong;
            PerfomanceQuality = 1f;
            _closeButton.transform.parent.gameObject.SetActive(false);
            GoTo(_countdown);
        }

        private void WrongNotePlayedHandler()
        {
            PerfomanceQuality -= _currentSong.Penalty;
        }
    }
}