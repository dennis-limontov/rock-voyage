using System;
using TMPro;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ProStudio : UIActiveOneChild
    {
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
                    default, RVGC.RecordAvailableDate);
            }
            else
            {
                _greetingsDoneText.text = GREETINGS_DONE;
                EventHub.OnValueChanged?.Invoke(GameAttributes.RecordCost,
                    default, Constants.PRO_STUDIO_RECORD_COST);
            }
        }
    }
}