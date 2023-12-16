using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/HouseInfo/ProStudioInfo")]
    public class ProStudioInfo : HouseInfo
    {
        public const int RECORD_COST = 50;
        public const int RECORD_AVAILABLE_DATE_PAUSE = 7;

        [SerializeField]
        private string _proStudioName;
        public string ProStudioName => _proStudioName;

        [SerializeField]
        private int _recordingCost;
        public int RecordingCost => _recordingCost;
    }
}