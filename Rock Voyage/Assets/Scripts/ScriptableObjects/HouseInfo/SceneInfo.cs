using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/HouseInfo/SceneInfo")]
    public class SceneInfo : HouseInfo
    {
        public const float PROFIT_PERCENT = 0.1f;

        [SerializeField]
        private int _fansCapacity;
        public int FansCapacity => _fansCapacity;
    }
}