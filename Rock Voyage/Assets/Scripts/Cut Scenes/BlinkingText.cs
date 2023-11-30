using System.Collections;
using UnityEngine;

namespace RockVoyage
{
    public class BlinkingText : MonoBehaviour
    {
        [SerializeField]
        private GameObject _blinkedObject;

        private const float BLINKING_TIME = 0.5f;

        public bool IsActivated => (_blinkingCoroutine != null);

        private IEnumerator _blinkingCoroutine;

        public void StartBlinking()
        {
            if (!IsActivated)
            {
                _blinkingCoroutine = ShowBlinkingText();
                StartCoroutine(_blinkingCoroutine);
            }
        }

        public void StopBlinking()
        {
            if (IsActivated)
            {
                StopCoroutine(_blinkingCoroutine);
                _blinkingCoroutine = null;
            }
        }

        private IEnumerator ShowBlinkingText()
        {
            WaitForSecondsRealtime wfsr = new WaitForSecondsRealtime(BLINKING_TIME);
            while (true)
            {
                _blinkedObject.SetActive(!_blinkedObject.activeSelf);

                yield return wfsr;
            }
        }
    }
}