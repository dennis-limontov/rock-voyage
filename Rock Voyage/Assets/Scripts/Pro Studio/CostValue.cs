using TMPro;

namespace RockVoyage
{
    public class CostValue : UIBase
    {
        private TextMeshProUGUI _costValueText;

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            _costValueText = GetComponent<TextMeshProUGUI>();
            _costValueText.text = Constants.PRO_STUDIO_RECORD_COST.ToString();
        }
    }
}