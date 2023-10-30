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

        private void Start()
        {
            RVGC.MapInfo = _mapInfo;
            _mapInfo.MapObjects = _mapObjects;
        }
    }
}