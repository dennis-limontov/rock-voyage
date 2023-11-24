using TMPro;

namespace RockVoyage
{
    public class CostValue : UIBase
    {
        private TextMeshProUGUI _costValueText;

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            _costValueText = GetComponent<TextMeshProUGUI>();
            _costValueText.text = Constants.PRO_STUDIO_RECORD_COST.ToString();
        }
    }
}