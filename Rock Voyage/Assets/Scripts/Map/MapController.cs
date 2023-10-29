using System.Collections;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class MapController : MonoBehaviour
    {
        [SerializeField]
        private float _gameSpeed;

        [SerializeField]
        private MapInfo _mapInfo;

        private void Start()
        {
            RVGC.MapInfo = _mapInfo;
            Time.timeScale = _gameSpeed;
            StartCoroutine(StartGameTime());
        }

        private IEnumerator StartGameTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                RVGC.ClockDate = RVGC.ClockDate.AddSeconds(1);
                MapEvents.OnClockDateChanged?.Invoke(RVGC.ClockDate);
            }
        }
    }
}