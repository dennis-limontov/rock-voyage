using JsonHelpers;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace RockVoyage
{
    [Serializable, DataContract]
    public class StreetMusicInfo : HouseInfo
    {
        public const float EARN_MONEY_CHANCE = 0.05f;
        public const float REMEMBER_CHANCE = 0.5f;
        public const float TIME_TO_PLAY = 30f;

        private DateTime _playAgainTime = DateTime.UnixEpoch;
        [DataMember]
        [SerializeIfGreaterThanCurrent]
        public DateTime PlayAgainTime
        {
            get => _playAgainTime;
            set
            {
                _playAgainTime = value;
                EventHub.OnValueChanged?.Invoke(GameAttributes.StreetMusicAvailableDate,
                    DateTime.UnixEpoch, value);
            }
        }

        public bool IsAvailable => _playAgainTime <= GameCharacteristics.ClockDate;
    }
}