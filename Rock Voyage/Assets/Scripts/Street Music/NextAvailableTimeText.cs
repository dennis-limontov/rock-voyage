using System.Globalization;
using TMPro;

namespace RockVoyage
{
    public class NextAvailableTimeText : UIBase
    {
        private TextMeshProUGUI _timeText;

        public override void Enter()
        {
            base.Enter();
            _timeText.text = ((StreetMusicInfo)houseInfo).PlayAgainTime
                .ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _timeText = GetComponent<TextMeshProUGUI>();
        }
    }
}