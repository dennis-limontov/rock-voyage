using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ProStudioInfo")]
    public class ProStudioInfo : HouseInfo
    {
        [SerializeField]
        private string _proStudioName;
        public string ProStudioName => _proStudioName;

        [SerializeField]
        private int _recordingCost;
        public int RecordingCost => _recordingCost;
    }
}