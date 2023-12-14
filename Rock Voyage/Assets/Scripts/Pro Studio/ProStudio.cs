using System;
using TMPro;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ProStudio : UIActiveOneChild
    {
        public const int RECORD_COST = 50;
        public const int RECORD_AVAILABLE_DATE_PAUSE = 7;

        [SerializeField]
        private TextMeshProUGUI _greetingsDoneText;

        private const string GREETINGS_DONE = "Well done! Record was awesome!";
        private const string GREETINGS_SORRY = "Sorry but you should wait a little.";

        public override void Enter()
        {
            base.Enter();
            if (RVGC.ClockDate <= RVGC.RecordAvailableDate)
            {
                _greetingsDoneText.text = GREETINGS_SORRY;
                GoToNext();
                EventHub.OnValueChanged?.Invoke(GameAttributes.RecordAvailableDate,
                    DateTime.UnixEpoch, RVGC.RecordAvailableDate);
            }
            else
            {
                _greetingsDoneText.text = GREETINGS_DONE;
                EventHub.OnValueChanged?.Invoke(GameAttributes.RecordCost, 0, RECORD_COST);
            }
        }
    }
}