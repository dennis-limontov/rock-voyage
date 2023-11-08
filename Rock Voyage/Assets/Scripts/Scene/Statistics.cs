using TMPro;
using UnityEngine;

namespace RockVoyage
{
    public class Statistics : UIBase
    {
        [SerializeField]
        private TextMeshProUGUI _perfomanceQualityPercent;

        [SerializeField]
        private TextMeshProUGUI _crowdHappinessPercent;

        [SerializeField]
        private TextMeshProUGUI _moneyProfitBucks;

        [SerializeField]
        private SceneInfo _sceneInfo;

        public void FillAllTexts(float perfomanceQuality, float crowdHappiness,
            int moneyProfit)
        {
            _perfomanceQualityPercent.text = (perfomanceQuality * 100f).ToString("f2") + " %";
            _crowdHappinessPercent.text = (crowdHappiness * 100f).ToString("f2") + " %";
            _moneyProfitBucks.text = moneyProfit.ToString() + " $   ";
        }
    }
}