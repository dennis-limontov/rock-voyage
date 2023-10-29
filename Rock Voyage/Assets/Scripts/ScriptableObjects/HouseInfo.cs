using UnityEngine;

namespace RockVoyage
{
    public abstract class HouseInfo : ScriptableObject
    {
        [SerializeField]
        private MapInfo _mapInfo;
        public MapInfo MapInfo => _mapInfo;

        [SerializeField]
        private string _sceneName;
        public string SceneName => _sceneName;
    }
}