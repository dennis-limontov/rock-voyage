using System;
using System.Runtime.Serialization;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    [Serializable, DataContract]
    public class ProStudioInfo : HouseInfo
    {
        public const int RECORD_AVAILABLE_DATE_PAUSE = 7;
        public const float FAME_INCREMENT = 0.01f;
        public static readonly TimeSpan RECORD_TIME = new TimeSpan(6, 0, 0);

        [field: SerializeField]
        public int RecordingCost { get; private set; }

        public void MakeRecord()
        {
            RVGC.Money -= RecordingCost;
            RVGC.Fame += FAME_INCREMENT;
            RVGC.RecordAvailableDate = RVGC.ClockDate.AddDays(RECORD_AVAILABLE_DATE_PAUSE);
            RVGC.ClockDate += RECORD_TIME;
        }
    }
}