using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SceneInfo")]
    public class SceneInfo : HouseInfo
    {
        [SerializeField]
        private int _fansCapacity;
        public int FansCapacity => _fansCapacity;
    }
}