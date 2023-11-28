using System.Collections;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private float _gameSpeed;

        private void Start()
        {
            StartCoroutine(StartGameTime());
        }

        private IEnumerator StartGameTime()
        {
            WaitForSeconds wfs = new WaitForSeconds(_gameSpeed);
            while (true)
            {
                yield return wfs;
                RVGC.ClockDate = RVGC.ClockDate.AddMinutes(1);
            }
        }
    }
}