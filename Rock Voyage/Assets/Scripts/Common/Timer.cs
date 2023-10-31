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
            while (true)
            {
                yield return new WaitForSeconds(_gameSpeed);
                RVGC.ClockDate = RVGC.ClockDate.AddMinutes(1);
            }
        }
    }
}