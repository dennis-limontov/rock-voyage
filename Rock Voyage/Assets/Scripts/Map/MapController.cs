using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class MapController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _mapObjects;

        [SerializeField]
        private MapInfo _mapInfo;

        [SerializeField]
        private Color _nightTime = Constants.NIGHT_MODE_COLOR;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            SceneManager.sceneLoaded += SceneLoadedHandler;
            Time.timeScale = 1f;
        }

        private void SceneLoadedHandler(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= SceneLoadedHandler;
            MapEvents.OnSceneLoaded?.Invoke(null);
            MapEvents.OnClockDateChanged?.Invoke(DateTime.UnixEpoch, RVGC.ClockDate);
            MapEvents.OnMoneyChanged?.Invoke(0, RVGC.Money);
        }

        private void OnDestroy()
        {
            MapEvents.OnClockDateChanged -= ClockDateChangedHandler;
        }

        private void Start()
        {
            RVGC.MapInfo = _mapInfo;
            _mapInfo.MapObjects = _mapObjects;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            MapEvents.OnClockDateChanged += ClockDateChangedHandler;
        }

        private void ClockDateChangedHandler(DateTime oldTime, DateTime newTime)
        {
            if ((newTime.Hour > Constants.NIGHT_MODE_HOURS_ON)
                || (newTime.Hour < Constants.NIGHT_MODE_HOURS_OFF))
            {
                _spriteRenderer.color = _nightTime;
            }
            else
            {
                _spriteRenderer.color = Color.white;
            }
        }
    }
}