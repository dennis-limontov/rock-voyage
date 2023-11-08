using System;
using System.Globalization;
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

        private char[] _resultKeys;
        public char[] ResultKeys => _resultKeys;

        private float _penalty;
        public float Penalty => _penalty;

        private float _noteLength;
        public float NoteLength => _noteLength;

        public void FillResultKeys()
        {
            if (_resultKeys != null)
            {
                return;
            }

            string[] _songKeys = KeysArray.text.Split(Environment.NewLine);
            int bars = int.Parse(_songKeys[0].Split(' ')[0]); // 113
            int divider = int.Parse(_songKeys[0].Split(' ')[1]); // 2
            _resultKeys = new char[bars * divider * 4]; // 904 = amount of 1/8 notes
            int m = 0;
            for (int i = 1; i < _songKeys.Length; i++)
            {
                try
                {
                    string[] keyInfo = _songKeys[i].Split(' '); // x 4 8 s 1.5 1
                    char key = char.Parse(keyInfo[0]); // x s
                    float keyDuration = float.Parse(keyInfo[1], CultureInfo.InvariantCulture); // 4 1.5
                    int keyAmount = int.Parse(keyInfo[2]); // 8 1

                    for (int j = 0; j < keyAmount; j++)
                    {
                        var localKey = key;
                        for (int k = 0; k < keyDuration * divider; k++)
                        {
                            _resultKeys[m++] = (localKey == '_') ? ' ' : localKey;

                            if ((k == 0) && (keyDuration > (1f / divider)))
                            {
                                localKey = ' ';
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Debug.Log($"There's an error in {i} line of {_songName} file.");
                    continue;
                }
            }

            _penalty = 1f / (bars * divider * 4f); // 1/904
            _noteLength = MusicForGroup.length / _resultKeys.Length; // 164/904 = 41/226
        }
    }
}