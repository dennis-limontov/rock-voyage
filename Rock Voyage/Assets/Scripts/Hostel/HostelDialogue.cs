using UnityEngine;

namespace RockVoyage
{
    public class HostelDialogue : MonoBehaviour
    {
        [SerializeField]
        private GameObject _variants1;

        [SerializeField]
        private GameObject _variants2;

        // Variant 1-1
        public void OnSpendTheNightClicked()
        {
            _variants1.SetActive(false);
            _variants2.SetActive(true);
        }

        // Variant 1-2
        public void OnBuyAMapClicked()
        {

        }

        // Variant 1-3
        public void OnBuyANewspaperClicked()
        {

        }

        // Variant 2-1
        public void OnGoToSleepClicked()
        {

        }

        // Variant 2-2
        public void OnBookARoomClicked()
        {

        }
    }
}