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
        private GameObject _mapObjects;

        [SerializeField]
        private MapInfo _mapInfo;

        public static MapController mapController;

        private void Start()
        {
            mapController = this;
            RVGC.MapInfo = _mapInfo;
            _mapInfo.MapObjects = _mapObjects;
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

        public void OnAnotherSceneLoaded()
        {
            Time.timeScale = 1;
        }

        public void OnAnotherSceneUnloaded()
        {
            Time.timeScale = _gameSpeed;
        }
    }
}