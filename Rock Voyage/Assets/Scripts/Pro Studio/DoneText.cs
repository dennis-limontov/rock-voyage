using TMPro;

namespace RockVoyage
{
    public class DoneText : UIBase
    {
        private const string DONE_TEXT = "Sorry but you should wait a little.";

        private TextMeshProUGUI _doneText;

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            _doneText = GetComponent<TextMeshProUGUI>();
            _doneText.text = DONE_TEXT;
        }
    }
}