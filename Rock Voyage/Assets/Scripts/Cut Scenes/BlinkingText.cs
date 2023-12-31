using System.Collections;
using UnityEngine;

namespace RockVoyage
{
    public class BlinkingText : MonoBehaviour
    {
        [SerializeField]
        private GameObject _blinkingObject;

        [SerializeField]
        private float _blinkingTime = 0.5f;

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
            WaitForSecondsRealtime wfsr = new WaitForSecondsRealtime(_blinkingTime);
            while (true)
            {
                _blinkingObject.SetActive(!_blinkingObject.activeSelf);

                yield return wfsr;
            }
        }
    }
}