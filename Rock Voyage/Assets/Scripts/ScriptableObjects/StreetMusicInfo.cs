using System;
using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/StreetMusicInfo")]
    public class StreetMusicInfo : HouseInfo
    {
        public bool IsAvailable => _playAgainTime <= GameCharacteristics.ClockDate;

        private DateTime _playAgainTime = DateTime.UnixEpoch;
        public DateTime PlayAgainTime
        {
            get => _playAgainTime;
            set => _playAgainTime = value;
        }
    }
}