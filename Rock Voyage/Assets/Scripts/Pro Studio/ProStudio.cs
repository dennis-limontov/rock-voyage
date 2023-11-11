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

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            if (RVGC.ClockDate <= RVGC.RecordAvailableDate)
            {
                _greetingsDoneText.text = GREETINGS_SORRY;
                GoToNext();
            }
            else
            {
                _greetingsDoneText.text = GREETINGS_DONE;
            }
        }
    }
}