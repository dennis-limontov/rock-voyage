using System;
using System.Collections;
using UnityEngine;

namespace RockVoyage
{
    public class MapController : MonoBehaviour
    {
        [SerializeField]
        private float _gameSpeed;

        private DateTime _clockDate;

        private void Start()
        {
            _clockDate = DateTime.UnixEpoch;
            Time.timeScale = _gameSpeed;
            StartCoroutine(StartGameTime());
        }

        private IEnumerator StartGameTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _clockDate = _clockDate.AddSeconds(1);
                MapEvents.OnClockDateChanged?.Invoke(_clockDate);
            }
        }
    }
}