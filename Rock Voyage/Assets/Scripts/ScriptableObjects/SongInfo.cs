using UnityEngine;

namespace RockVoyage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SongInfo")]
    public class SongInfo : ScriptableObject
    {
        [SerializeField]
        private AudioClip _musicForSinger;
        public AudioClip MusicForSinger => _musicForSinger;

        [SerializeField]
        private AudioClip _musicForGroup;
        public AudioClip MusicForGroup => _musicForGroup;

        [SerializeField]
        private TextAsset _keysArray;
        public TextAsset KeysArray => _keysArray;

        [SerializeField]
        private string _songName;
        public string SongName => _songName;

        [SerializeField]
        private bool _isUnique;
        public bool IsUnique => _isUnique;

        [SerializeField]
        private float _prominence;
        public float Prominence => _prominence;
    }
}