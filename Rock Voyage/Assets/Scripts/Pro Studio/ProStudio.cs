using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class ProStudio : MonoBehaviour
    {
        [SerializeField]
        private GameObject _donePanel;
        
        [SerializeField]
        private TextMeshProUGUI _doneText;

        [SerializeField]
        private TextMeshProUGUI _newRecordDateText;

        [SerializeField]
        private GameObject _greetingsPanel;

        [SerializeField]
        private TextMeshProUGUI _costValueText;

        [SerializeField]
        private Button _goButton;

        public static bool IsRecordAvailable => (RVGC.ClockDate > RVGC.RecordAvailableDate);

        private const string DONE_TEXT = "Sorry but you should wait a little.";

        private void Start()
        {
            if (IsRecordAvailable)
            {
                _costValueText.text = Constants.PRO_STUDIO_RECORD_COST.ToString();
                _goButton.interactable = (RVGC.Money >= Constants.PRO_STUDIO_RECORD_COST);
            }
            else
            {
                ShowNewRecordInfo();
                _doneText.text = DONE_TEXT;
            }
        }

        public void OnGoButtonClick()
        {
            RVGC.Money -= Constants.PRO_STUDIO_RECORD_COST;
            RVGC.Fame += Constants.FAME_INCREMENT;
            RVGC.RecordAvailableDate = RVGC.ClockDate.AddDays(7);
            ShowNewRecordInfo();
            RVGC.ClockDate += Constants.PRO_STUDIO_TIME;
        }

        private void ShowNewRecordInfo()
        {
            _donePanel.transform.gameObject.SetActive(true);
            _greetingsPanel.transform.gameObject.SetActive(false);
            _newRecordDateText.text = RVGC.RecordAvailableDate
                .ToString(Constants.DATE_STRING_FORMAT, CultureInfo.InvariantCulture);
        }
    }
}