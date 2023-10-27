using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class Statistics : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _perfomanceQualityPercent;

        [SerializeField]
        private TextMeshProUGUI _crowdHappinessPercent;

        [SerializeField]
        private TextMeshProUGUI _moneyProfitBucks;

        public void FillAllTexts(float perfomanceQuality, float crowdHappiness,
            int moneyProfit)
        {
            _perfomanceQualityPercent.text = (perfomanceQuality * 100f).ToString("f2") + " %";
            _crowdHappinessPercent.text = (crowdHappiness * 100f).ToString("f2") + " %";
            _moneyProfitBucks.text = moneyProfit.ToString() + " $   ";
        }

        public void OnButtonOKPressed()
        {
            SceneManager.LoadScene(Constants.MAP_SCENE);
        }
    }
}