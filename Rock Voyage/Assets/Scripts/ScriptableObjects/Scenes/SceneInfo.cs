using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Scenes/SceneInfo")]
    public class SceneInfo : HouseInfo
    {
        [SerializeField]
        private int _fansCapacity;
    }
}