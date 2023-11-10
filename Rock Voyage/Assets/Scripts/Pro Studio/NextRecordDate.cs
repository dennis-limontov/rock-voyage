using System.Globalization;
using TMPro;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class NextRecordDate : UIBase
    {
        private TextMeshProUGUI _nextRecordDateText;

        public override void Enter()
        {
            base.Enter();
            _nextRecordDateText.text = RVGC.RecordAvailableDate
                .ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
        }

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            _nextRecordDateText = GetComponent<TextMeshProUGUI>();
        }
    }
}