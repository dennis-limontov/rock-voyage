using System;
using UnityEngine;
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
            Time.timeScale = 1f;
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

            EventHub.Initialize();
            MapEvents.OnClockDateChanged?.Invoke(DateTime.UnixEpoch, GameCharacteristics.ClockDate);
            MapEvents.OnMoneyChanged?.Invoke(0, GameCharacteristics.Money);
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