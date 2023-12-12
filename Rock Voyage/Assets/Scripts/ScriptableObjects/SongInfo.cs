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

        [SerializeField]
        private string _songName;
        public string SongName => _songName;

        [SerializeField]
        private bool _isUnique;
        public bool IsUnique => _isUnique;

        [SerializeField]
        private float _prominence;
        public float Prominence => _prominence;

        public char[] SongKeys { get; private set; }
        public float Penalty { get; private set; }
        public float NoteLength { get; private set; }

        public void FillResultKeys()
        {
            if ((SongKeys != null) && (SongKeys.Length != 0))
            {
                return;
            }

            string[] songKeys = _keysArray.text.Split(Environment.NewLine);
            int[] headerInfo = Array.ConvertAll(songKeys[0].Split(' '), int.Parse);
            int bars = headerInfo[0]; // 113
            int divider = headerInfo[1]; // 2
            SongKeys = new char[bars * divider * 4]; // 904 = amount of 1/8 notes
            int m = 0;
            for (int i = 1; i < songKeys.Length; i++)
            {
                try
                {
                    string[] keyInfo = songKeys[i].Split(' '); // x 4 8 s 1.5 1
                    char key = char.Parse(keyInfo[0]); // x s
                    float keyDuration = float.Parse(keyInfo[1], CultureInfo.InvariantCulture); // 4 1.5
                    int keyAmount = int.Parse(keyInfo[2]); // 8 1

                    for (int j = 0; j < keyAmount; j++)
                    {
                        var localKey = key;
                        for (int k = 0; k < keyDuration * divider; k++)
                        {
                            SongKeys[m++] = (localKey == '_') ? ' ' : localKey;

                            if ((k == 0) && (keyDuration > (1f / divider)))
                            {
                                localKey = ' ';
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Debug.LogError($"There's an error in {i} line of {_songName} file.");
                }
            }

            Penalty = 1f / (bars * divider * 4f); // 1/904
            NoteLength = MusicForGroup.length / SongKeys.Length; // 164/904 = 41/226
        }
    }
}